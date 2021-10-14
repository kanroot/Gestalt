using Godot;

namespace Gestalt.Movements.Player
{
	public class PlayerMovement : MovementBase
	{
		public PlayerMovement(KinematicBody2D entity, float speed, bool canMove) : base(entity, speed)
		{
		}

		public override void DoMovement(float delta)
		{
			Entity.MoveAndSlide(GetInputMovement());
		}

		private Vector2 GetInputMovement()
		{
			var directionPlayerVector = new Vector2();

			if (Input.IsActionPressed("ui_right"))
				directionPlayerVector.x += 1;

			if (Input.IsActionPressed("ui_left"))
				directionPlayerVector.x -= 1;

			if (Input.IsActionPressed("ui_down"))
				directionPlayerVector.y = 1;

			if (Input.IsActionPressed("ui_up"))
				directionPlayerVector.y -= 1;

			return directionPlayerVector * Speed;
		}
	}
}