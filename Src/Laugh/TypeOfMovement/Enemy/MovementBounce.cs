using Godot;
using Laugh.Movement.Enemy;

namespace Laugh.TypeOfMovement.Enemy
{
	public class MovementBounce : MovementBase
	{
		private Vector2 directionDemon = new Vector2(1, 0);
		
		public override void DoMovement(float delta)
		{
			if (CanMove != true) return;
			var collision = Entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}

		public MovementBounce(KinematicBody2D entity, float speed, bool canMove) : base(entity, speed, canMove)
		{
		}
	}
}