using Godot;

namespace Laugh.Movement.Demon
{
	public class Bounce : CanMoveBase
	{
		[Export] private Vector2 directionDemon = new Vector2(1, 0);
		
		
		public override void _Process(float delta)
		{
			MoveTo(delta);
		}

		protected override void MoveTo(float delta)
		{
			if (CanMove != true) return;
			var collision = entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}

		
			
	}
}