using Godot;

namespace Laugh.Movement.Enemy
{
	public class MoveTowardsPlayer : CanMoveBase
	{
		private Vector2 positionPlayer;

		public MoveTowardsPlayer(KinematicBody2D entity, bool canMove, float speed) : base(entity, canMove, speed)
		{
		}

		protected override void PerformMovement(float delta)
		{
			if (CanMove != true) return;
			if (Entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - Entity.GlobalPosition).Normalized();
			Entity.MoveAndCollide(dir * Speed * delta);
		}

		public void UpdatePositionPlayer(KinematicBody2D player)
		{
			CanMove = true;
			positionPlayer = player.GlobalPosition;
		}
	}
}