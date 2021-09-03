using Godot;

namespace Laugh.Movement.Demon
{
	public class MoveToPlayer : CanMoveBase
	{
		private Vector2 positionPlayer;
		
		public override void MoveTo(float delta)
		{
			if (CanMove != true) return;
			if (Entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - Entity.GlobalPosition).Normalized();
			Entity.MoveAndCollide(dir * Speed * delta);
		}

		public void UpdatePositionPlayer(Node2D player)
		{
			CanMove = true;
			positionPlayer = player.GlobalPosition;
		}

		public MoveToPlayer(KinematicBody2D entity, bool canMove, float speed) : base(entity, canMove, speed)
		{
		}
	}
}