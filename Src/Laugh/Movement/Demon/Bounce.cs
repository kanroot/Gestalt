using Godot;

namespace Laugh.Movement.Demon
{
	public class Bounce : CanMoveBase
	{
		private Vector2 directionDemon = new Vector2(1, 0);
		
		public override void MoveTo(float delta)
		{
			if (CanMove != true) return;
			var collision = Entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}
		
		public Bounce(KinematicBody2D entity, bool canMove, float speed) : base(entity, canMove, speed)
		{
		}
	}
}