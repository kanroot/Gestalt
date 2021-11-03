using Godot;

namespace Gestalt.Text
{
	public class CanMoveBody : CanMovementText
	{
		protected Sprite body;
		[Export] private NodePath bodyPath;
		[Export] private bool canPopUp;
		protected int count;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		protected int secondCount;


		public override void _Ready()
		{
			base._Ready();
			entity = GetNode<KinematicBody2D>(entityPath);
			body = GetNode<Sprite>(bodyPath);
			if (!canPopUp) return;
			entity.Scale = new Vector2((float)0.1, (float)0.1);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			count += DegreesRotate;
			RotateBody(count);
			PopUp();
		}

		protected virtual void RotateBody(int degrees)
		{
			if (degrees > 180)
			{
				body.Rotate(DegreesToRadiant * -1);
				secondCount++;
			}

			if (secondCount <= 360) return;
			count = 0;
			secondCount = 0;
		}

		private void PopUp()
		{
			if (canPopUp == false) return;
			if (entity.Scale < new Vector2(1, 1)) entity.Scale *= (float)1.05;

			if (entity.Scale > new Vector2((float)0.88, (float)0.88))
				entity.Scale = new Vector2((float)0.88, (float)0.88);
		}
	}
}