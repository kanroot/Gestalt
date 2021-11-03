using Godot;

namespace Gestalt.Scenes
{
	public class Main : Control
	{
		private VBoxContainer buttons;
		private Button exit;
		private Button play;
		[Export] private PackedScene transition;

		public override void _Ready()
		{
			buttons = GetChild<VBoxContainer>(1);
			play = buttons.GetChild<Button>(0);
			exit = buttons.GetChild<Button>(1);
			play.Connect("pressed", this, nameof(ChangeToTransition));
			exit.Connect("pressed", this, nameof(CloseGame));
		}

		private void ChangeToTransition()
		{
			GetTree().ChangeScene(transition.ResourcePath);
		}

		private void CloseGame()
		{
			GetTree().Quit();
		}
	}
}