using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Godot;

// Originally written by wmigor
// Edited by Atlinx to recursively search for files.
// wmigor's Public Repo: https://github.com/wmigor/godot-mono-custom-resource-register
namespace MonoCustomResourceRegistry
{
#if TOOLS
	[Tool]
	public class Plugin : EditorPlugin
	{
		// We're not going to hijack the Mono Build button since it actually takes time to build
		// and we can't be sure how long that is. I guess we have to leave refreshing to the user for now.
		// There isn't any automation we can do to fix that.
		// private Button MonoBuildButton => GetNode<Button>("/root/EditorNode/@@580/@@581/@@589/@@590/ToolButton");
		private readonly List<string> customTypes = new List<string>();
		private Button refreshButton;

		public override void _EnterTree()
		{
			refreshButton = new Button();
			refreshButton.Text = "CCR";

			AddControlToContainer(CustomControlContainer.Toolbar, refreshButton);
			refreshButton.Icon = refreshButton.GetIcon("Reload", "EditorIcons");
			refreshButton.Connect("pressed", this, nameof(OnRefreshPressed));

			Settings.Init();
			RefreshCustomClasses();
			GD.PushWarning(
				"You may change any setting for MonoCustomResourceRegistry in Project -> ProjectSettings -> General -> MonoCustomResourceRegistry");
		}

		public override void _ExitTree()
		{
			UnregisterCustomClasses();
			RemoveControlFromContainer(CustomControlContainer.Toolbar, refreshButton);
			refreshButton.QueueFree();
		}

		public void RefreshCustomClasses()
		{
			GD.Print("\nRefreshing Registered Resources...");
			UnregisterCustomClasses();
			RegisterCustomClasses();
		}

		private void RegisterCustomClasses()
		{
			customTypes.Clear();

			var file = new File();

			foreach (var type in GetCustomRegisteredTypes())
				if (type.IsSubclassOf(typeof(Resource)))
					AddRegisteredType(type, nameof(Resource), file);
				else
					AddRegisteredType(type, nameof(Node), file);
		}

		private void AddRegisteredType(Type type, string defaultBaseTypeName, File file)
		{
			var attribute =
				(RegisteredTypeAttribute)Attribute.GetCustomAttribute(type, typeof(RegisteredTypeAttribute));
			var path = FindClassPath(type);
			if (path == null && !file.FileExists(path))
				return;
			var script = GD.Load<Script>(path);
			if (script == null)
				return;
			var baseType = defaultBaseTypeName;
			if (attribute.baseType != "")
				baseType = attribute.baseType;
			ImageTexture icon = null;
			if (attribute.iconPath != "")
			{
				if (file.FileExists(attribute.iconPath))
				{
					var rawIcon = ResourceLoader.Load<Texture>(attribute.iconPath);
					if (rawIcon != null)
					{
						var image = rawIcon.GetData();
						var length = (int)Mathf.Round(16 * GetEditorInterface().GetEditorScale());
						image.Resize(length, length);
						icon = new ImageTexture();
						icon.CreateFromImage(image);
					}
					else
					{
						GD.PushError(
							$"Could not load the icon for the registered type \"{type.FullName}\" at path \"{path}\".");
					}
				}
				else
				{
					GD.PushError(
						$"The icon path of \"{path}\" for the registered type \"{type.FullName}\" does not exist.");
				}
			}

			AddCustomType($"{Settings.ClassPrefix}{type.Name}", baseType, script, icon);
			customTypes.Add($"{Settings.ClassPrefix}{type.Name}");
			GD.Print($"Registered custom type: {type.Name} -> {path}");
		}

		private static string FindClassPath(Type type)
		{
			switch (Settings.SearchType)
			{
				case Settings.ResourceSearchType.Recursive:
					return FindClassPathRecursive(type);
				case Settings.ResourceSearchType.Namespace:
					return FindClassPathNamespace(type);
				default:
					throw new Exception($"ResourceSearchType {Settings.SearchType} not implemented!");
			}
		}

		private static string FindClassPathNamespace(Type type)
		{
			foreach (var dir in Settings.ResourceScriptDirectories)
			{
				var filePath = $"{dir}/{type.Namespace?.Replace(".", "/") ?? ""}/{type.Name}.cs";
				var file = new File();
				if (file.FileExists(filePath))
					return filePath;
			}

			return null;
		}

		private static string FindClassPathRecursive(Type type)
		{
			foreach (var directory in Settings.ResourceScriptDirectories)
			{
				var fileFound = FindClassPathRecursiveHelper(type, directory);
				if (fileFound != null)
					return fileFound;
			}

			return null;
		}

		private static string FindClassPathRecursiveHelper(Type type, string directory)
		{
			var dir = new Directory();

			if (dir.Open(directory) == Error.Ok)
			{
				dir.ListDirBegin();

				while (true)
				{
					var fileOrDirName = dir.GetNext();

					// Skips hidden files like .
					if (fileOrDirName == "") break;

					if (fileOrDirName.BeginsWith(".")) continue;

					if (dir.CurrentIsDir())
					{
						var foundFilePath =
							FindClassPathRecursiveHelper(type, dir.GetCurrentDir() + "/" + fileOrDirName);
						if (foundFilePath != null)
						{
							dir.ListDirEnd();
							return foundFilePath;
						}
					}
					else if (fileOrDirName == $"{type.Name}.cs")
					{
						return dir.GetCurrentDir() + "/" + fileOrDirName;
					}
				}
			}

			return null;
		}

		private static IEnumerable<Type> GetCustomRegisteredTypes()
		{
			var assembly = Assembly.GetAssembly(typeof(Plugin));
			return assembly.GetTypes().Where(t => !t.IsAbstract
			                                      && Attribute.IsDefined(t, typeof(RegisteredTypeAttribute))
			                                      && (t.IsSubclassOf(typeof(Node)) || t.IsSubclassOf(typeof(Resource)))
			);
		}

		private void UnregisterCustomClasses()
		{
			foreach (var script in customTypes)
			{
				RemoveCustomType(script);
				GD.Print($"Unregister custom resource: {script}");
			}

			customTypes.Clear();
		}

		private void OnRefreshPressed()
		{
			RefreshCustomClasses();
		}
	}
#endif
}