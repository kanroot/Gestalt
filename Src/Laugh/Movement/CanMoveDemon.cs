using Godot;

namespace Laugh.Movement
{
	public class CanMoveDemon : CanMoveBase
	{
		[Export] private Vector2 directionDemon = new Vector2(1, 0);

		private Node2D positionPlayer;

		public bool ChangePatternMove { get; set; } = false;

		protected override void Movement(float delta)
		{
			if (ChangePatternMove == false)
				BounceMovement(delta);
			else
				DirectionPlayer(delta);
		}

		private void BounceMovement(float delta)
		{
			if (CanMove != true) return;
			var collision = entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}

		private void DirectionPlayer(float delta)
		{
			var dir = (positionPlayer.GlobalPosition - entity.GlobalPosition).Normalized();
			entity.MoveAndCollide(dir * Speed * delta);
		}

		public void UpdatePositionPlayer(Node2D player)
		{
			positionPlayer = player;
		}
	}
}