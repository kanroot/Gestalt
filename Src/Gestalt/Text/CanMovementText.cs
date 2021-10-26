using System;
using Godot;

namespace Gestalt.Text
{
	public class CanMovementText : Node
	{
		[Export] private int degreesRotate;
		[Export] private NodePath pathTextRotated;
		[Export()] private NodePath bodyPath;
		private Sprite textRotated;
		private Sprite body;
		private int count;
		private int secondCount;

		public override void _Ready()
		{
			textRotated = GetNode<Sprite>(pathTextRotated);
			body = GetNode<Sprite>(bodyPath);
		}

		public override void _Process(float delta)
		{
			count += degreesRotate; 
			var degreesToRadiant = Math.PI / 180 * degreesRotate;
			textRotated.Rotate((float)degreesToRadiant);
			if (count < 360) return;
			body.Rotate((float)degreesToRadiant);
			secondCount += 1;
			if (secondCount < 360) return;
			count = 0;
			secondCount = 0;
		}
	}
}