namespace Laugh.IA.FSM.State
{
	public abstract class StateBase
	{
		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract bool ShouldTransition();
	}
}