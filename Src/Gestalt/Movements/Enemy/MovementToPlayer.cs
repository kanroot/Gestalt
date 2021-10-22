using Godot;

namespace Gestalt.Movements.Enemy
{
	public class MovementToPlayer : MovementBase
	{
		private Vector2 positionPlayer;

		public MovementToPlayer(KinematicBody2D entity, float speed) : base(entity, speed)
		{
		}

		public Area2D AreaDetect { get; set; }

		public override void DoMovement(float delta)
		{
			if (Entity.GlobalPosition.Round().DistanceTo(positionPlayer.Round()) < 8) return;
			var dir = (positionPlayer - Entity.GlobalPosition).Normalized();
			Entity.MoveAndCollide(dir * Speed * delta);
		}

		private void UpdatePositionPlayer(KinematicBody2D player)
		{
			positionPlayer = player.GlobalPosition;
		}

		public bool OnBodyEntered(KinematicBody2D player)
		{
			if (!player.IsInGroup("player")) return false;
			UpdatePositionPlayer(player);
			ResetForm();
			return true;
		}

		public void GrowAreaDetect()
		{
			AreaDetect.Scale *= (float)1.5;
		}

		public void ResetForm()
		{
			AreaDetect.Scale = new Vector2(1, 1);
		}
	}
}