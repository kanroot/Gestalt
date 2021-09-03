using Godot;

namespace Laugh.Movement.Demon
{
	public class MoveToPlayer : CanMoveBase
	{
		private Vector2 positionPlayer;

		public override void _Process(float delta)
		{
			MoveTo(delta);
		}

		protected override void MoveTo(float delta)
		{
			if (CanMove != true) return;
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