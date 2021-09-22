using Godot;

namespace Laugh.Movement
{
	public abstract class CanMoveBase : Node
	{
		public bool CanMove;
		protected KinematicBody2D Entity;
		protected float Speed;

		protected CanMoveBase(KinematicBody2D entity, bool canMove, float speed)
		{
			Entity = entity;
			CanMove = canMove;
			Speed = speed;
		}

		public override void _Process(float delta)
		{
			PerformMovement(delta);
		}

		protected abstract void PerformMovement(float delta);

		public void SpeedChange(float multiplier)
		{
			Speed = (int)(Speed * multiplier);
		}
	}
}