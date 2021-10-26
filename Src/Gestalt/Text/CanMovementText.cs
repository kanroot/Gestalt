using System;
using Godot;

namespace Gestalt.Text
{
	public class CanMovementText : Node
	{
		[Export] private int degreesRotate;
		[Export] private NodePath pathTextRotated;
		[Export()] private NodePath bodyPath;
		[Export()] private Boolean CanMoveBody { get; set; }
		private Sprite textRotated;
		private Sprite body;
		private int count;
		private int secondCount;
		private double degreesToRadiant;

		public override void _Ready()
		{
			textRotated = GetNode<Sprite>(pathTextRotated);
			body = GetNode<Sprite>(bodyPath);
		}

		public override void _Process(float delta)
		{
			count += degreesRotate; 
			degreesToRadiant = Math.PI / 180 * degreesRotate;
			textRotated.Rotate((float)degreesToRadiant);
			RotateBody(count);
			
		}

		private void RotateBody(int degrees)
		{
			if (degrees > 180 && CanMoveBody){
				body.Rotate((float)degreesToRadiant);
				secondCount++;
			}
			if (secondCount >= 360)
			{
				count = 0;
				secondCount = 0;
			};
		}
	}
}