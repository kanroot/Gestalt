using Laugh.IA.FSM.State;
using Laugh.Movement;

namespace Laugh.IA.FSM.Demon
{
	public class MoveAttack : StateBase
	{
		private readonly CanMoveBase canMoveBase;

		public MoveAttack(CanMoveBase canMoveBase)
		{
			this.canMoveBase = canMoveBase;
		}

		public override void OnEnter()
		{
			canMoveBase.CanMove = true;
		}

		public override void OnExit()
		{
			canMoveBase.CanMove = false;
		}

		public override bool ShouldTransition()
		{
			//implementar una señal cuando la vida sea inferior a cierto %
			return true;
		}
	}
}