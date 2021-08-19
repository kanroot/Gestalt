using Godot;

namespace Laugh.Movement
{
	public class CanMoveDemon : CanMoveBase
	{
		[Export] private Vector2 directionDemon = new Vector2(1, 0);

		protected override void Movement(float delta)
		{
			DirectionDemonBounce(delta);
		}

		private void DirectionDemonBounce(float delta)
		{
			if (CanMove != true) return;
			//muevo al personaje segun colisione, la nueva direccion sera entanto la direccion de rebote
			var collision = entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}
	}
}