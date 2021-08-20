using Laugh.Life;
using Laugh.Movement;

namespace Laugh.IA.FSM
{
	public class MovementAttackState : State
	{
		private readonly CanMoveBase canMoveBase;
		
		public MovementAttackState( CanMoveBase canMoveBase , State nextState, LifeBase lifeBase): base(nextState, lifeBase) 
		{
			this.canMoveBase = canMoveBase;
		}
		

		public override void OnStateEnter()
		{
			canMoveBase.CanMove = true;
		}

		public override void OnStateExit()
		{
			canMoveBase.CanMove = false;
		}

		public override bool ShouldTransition()
		{
			//if base.life = cantida return true;
			return true;
		}
	}
}