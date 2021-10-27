using System;
using Godot;

namespace Gestalt.Text
{
	public class CanMovementText : Node
	{
		[Export] public int DegreesRotate;
		protected float DegreesToRadiant;
		[Export] private NodePath pathTextRotated;
		private Sprite textRotated;

		public override void _Ready()
		{
			textRotated = GetNode<Sprite>(pathTextRotated);
		}

		public override void _Process(float delta)
		{
			DegreesToRadiant = (float)(Math.PI / 180 * DegreesRotate);
			textRotated.Rotate(DegreesToRadiant);
		}
	}
}