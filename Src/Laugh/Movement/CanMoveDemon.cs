using Godot;

namespace Laugh.Movement
{
	public class CanMoveDemon : CanMoveBase
	{
		[Export] private Vector2 directionDemon = new Vector2(1, 0);

		public Vector2 positionPlayer;

		public bool CanChangeMovement { get; set; } = false;

		protected override void Movement(float delta)
		{
			MoveToPlayer(delta);
		}

		private void DoBounce(float delta)
		{
			if (CanMove != true) return;
			var collision = entity.MoveAndCollide(directionDemon * Speed * delta);
			if (collision != null) directionDemon = directionDemon.Bounce(collision.Normal);
		}

		private void MoveToPlayer(float delta)
		{
			if (entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - entity.GlobalPosition).Normalized();
			entity.MoveAndCollide(dir * Speed * delta);
		}

		public void UpdatePositionPlayer(Node2D player)
		{
			positionPlayer = player.GlobalPosition;
		}
	}
}