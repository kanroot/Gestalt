namespace Laugh.IA.FSM.Enemy
{
	public abstract class StateBase
	{
		protected StateBase CurrentState;
		public abstract void OnEnter();
		public abstract void OnExit();
	}
}