using Godot;

namespace Laugh.Movement.Enemy
{
	public class BounceMovement : CanMoveBase
	{
		private Vector2 directionDemon = new Vector2(1, 0);
		
		protected override void PerformMovement(float delta)
		{
			if (CanMove != true) return;
			var collision = Entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}

		public BounceMovement(KinematicBody2D entity, bool canMove, float speed) : base(entity, canMove, speed){}
	}
}