using Laugh.Life;

namespace Laugh.IA.FSM
{
	public abstract class StateBase
	{
		protected LifeBase Life;
		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract bool ShouldTransition();
	}
}