using Godot;

namespace Gestalt.Movements
{
	public abstract class MovementBase
	{
		protected KinematicBody2D Entity;
		protected float Speed;

		protected MovementBase(KinematicBody2D entity, float speed)
		{
			Entity = entity;
			Speed = speed;
		}
		public abstract void DoMovement(float delta);
	}
}