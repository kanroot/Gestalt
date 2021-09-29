using Godot;

namespace Laugh.TypeOfMovement.Enemy
{
	public class MovementBounce : MovementBase
	{
		private Vector2 directionDemon = new Vector2(1, 0);

		public MovementBounce(KinematicBody2D entity, float speed, bool canMove) : base(entity, speed, canMove)
		{
		}

		public override void DoMovement(float delta)
		{
			if (CanMove != true) return;
			var collision = Entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}
	}
}