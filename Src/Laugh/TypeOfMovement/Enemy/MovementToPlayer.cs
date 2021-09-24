using Godot;
using Laugh.TypeOfMovement;
using Laugh.TypeOfMovement.Enemy;

namespace Laugh.Movement.Enemy
{
	public class MovementToPlayer : MovementBase
	{
		private Vector2 positionPlayer;
		
		public MovementToPlayer(KinematicBody2D entity, float speed, bool canMove) : base(entity, speed, canMove)
		{
		}

		public override void DoMovement(float delta)
		{
			if (CanMove != true) return;
			if (Entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - Entity.GlobalPosition).Normalized();
			Entity.MoveAndCollide(dir * Speed * delta);
		}
		
		public void UpdatePositionPlayer(KinematicBody2D player)
		{
			positionPlayer = player.GlobalPosition;
		}
	}
}