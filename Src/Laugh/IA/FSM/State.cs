#nullable enable
using Laugh.Life;
namespace Laugh.IA.FSM
{
	public abstract class State
	{
		public State NextState { get; set; }
		protected LifeBase lifeBase;
		
		//este metodo lo llamo cuando quiero que actue el estado
		public abstract void OnStateEnter();
		public abstract void OnStateExit();

		public abstract bool ShouldTransition();

		protected State(State nextState, LifeBase lifeBase)
		{
			NextState = nextState;
			this.lifeBase = lifeBase;
		}
	}
}