using Godot;

namespace Laugh.TypeOfMovement
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

		public abstract void PerformMovement(float delta);

		public void SpeedChange(float multiplier)
		{
			Speed = (int)(Speed * multiplier);
		}
	}
}