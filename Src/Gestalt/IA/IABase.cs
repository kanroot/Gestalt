using Godot;

namespace Gestalt.IA
{
	public abstract class IABase : Node
	{
		protected KinematicBody2D Entity;
		[Export] protected NodePath EntityPath;

		public override void _Ready()
		{
			Entity = GetNode<KinematicBody2D>(EntityPath);
		}
	}
}