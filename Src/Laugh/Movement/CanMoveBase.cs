using Godot;

namespace Laugh.Movement
{
	public abstract class CanMoveBase : Node
	{
		protected KinematicBody2D entity;

		[Export] private NodePath entityPath;

		[Export] protected int Speed = 200;
		protected abstract void Movement(float delta);

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public override void _PhysicsProcess(float delta)
		{
			Movement(delta);
		}

		public void SpeedChange(float multiplier)
		{
			Speed = (int)(Speed * multiplier);
		}
	}
}