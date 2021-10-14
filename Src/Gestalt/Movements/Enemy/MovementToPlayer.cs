using Godot;

namespace Gestalt.Movements.Enemy
{
	public class MovementToPlayer : MovementBase
	{
		private Vector2 positionPlayer;
		
		public override void DoMovement(float delta)
		{
			if (Entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - Entity.GlobalPosition).Normalized();
			Entity.MoveAndCollide(dir * Speed * delta);
		}

		public void UpdatePositionPlayer(KinematicBody2D player)
		{
			positionPlayer = player.GlobalPosition;
		}

		public MovementToPlayer(KinematicBody2D entity, float speed) : base(entity, speed)
		{
		}
	}
}