using System;
using Godot;

namespace Gestalt.Movement
{
	public class CanMovementText : Node
	{
		[Export] private NodePath pathTextRotated;
		[Export] private int degreesRotate;
		private Sprite textRotated;

		public override void _Ready()
		{
			textRotated = GetNode<Sprite>(pathTextRotated);
		}

		public override void _PhysicsProcess(float delta)
		{
			var degreesToRadiant = (Math.PI / 180) * degreesRotate;
			textRotated.Rotate((float)degreesToRadiant);
		}
	}
}