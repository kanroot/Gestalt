using Godot;

namespace Gestalt.Text
{
	public class CanMoveBody : CanMovementText
	{
		private Sprite body;
		[Export] private NodePath bodyPath;
		private int count;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private int secondCount;

		public override void _Ready()
		{
			base._Ready();
			entity = GetNode<KinematicBody2D>(entityPath);
			body = GetNode<Sprite>(bodyPath);
			entity.Scale = new Vector2((float)0.1, (float)0.1);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			count += DegreesRotate;
			RotateBody(count);
			PopUp();
		}

		private void RotateBody(int degrees)
		{
			if (degrees > 180)
			{
				body.Rotate(DegreesToRadiant);
				secondCount++;
			}

			if (secondCount >= 360)
			{
				count = 0;
				secondCount = 0;
			}

			;
		}

		private void PopUp()
		{
			if (entity.Scale < new Vector2(1, 1)) entity.Scale *= (float)1.05;

			if (entity.Scale > new Vector2(1, 1)) entity.Scale = new Vector2(1, 1);
		}
	}
}