using Godot;

namespace Laugh.TypeOfMovement
{
	public abstract class MovementBase
	{
		protected KinematicBody2D Entity;
		protected float Speed;

		protected MovementBase(KinematicBody2D entity, float speed, bool canMove)
		{
			Entity = entity;
			Speed = speed;
			CanMove = canMove;
		}

		protected bool CanMove { get; set; }
		public abstract void DoMovement(float delta);
	}
}