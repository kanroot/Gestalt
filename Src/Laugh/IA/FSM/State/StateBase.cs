using Godot;

namespace Laugh.IA.FSM.State
{
	public abstract class StateBase : Node
	{

		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract bool ShouldTransition();
	}
}