using Godot;

namespace Laugh.Movement
{
	public abstract class CanMoveBase : Node
	{
		[Export()] private NodePath entityPath;
		protected KinematicBody2D entity;
		
		[Export] public int Speed { get; set; }

		[Export] public bool CanMove { set; get; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public override void _Process(float delta)
		{
			MoveTo(delta);
		}

		protected abstract void MoveTo(float delta);
		public void SpeedChange(float multiplier)
		{
			Speed = (int)(Speed * multiplier);
		}
	}
}