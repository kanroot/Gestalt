using Godot;

namespace Laugh.IA
{
	public abstract class IABase : Node
	{
		protected KinematicBody2D entity;
		[Export] private NodePath entityPath;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}
	}
}