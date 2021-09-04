using Godot;

namespace Laugh.Movement
{
	public abstract class CanMoveBase : Node
	{
		protected KinematicBody2D Entity;
		public bool CanMove;
		protected float Speed;

		public CanMoveBase(KinematicBody2D entity, bool canMove, float speed)
		{
			this.Entity = entity;
			this.CanMove = canMove;
			this.Speed = speed;
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