using Godot;

namespace Laugh.IA.FSM.State
{
	public abstract class  PatternBase : Node
	{
		protected KinematicBody2D entity;

		public PatternBase(KinematicBody2D entity)
		{
			this.entity = entity;
		}
	}
}