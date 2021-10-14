using Godot;

namespace Gestalt.Movements.Enemy
{
	public class MovementBounce : MovementBase
	{
		private Vector2 directionDemon = new Vector2(1, 0);

		public MovementBounce(KinematicBody2D entity, float speed) : base(entity, speed)
		{
		}

		public override void DoMovement(float delta)
		{
			var collision = Entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}
	}
}