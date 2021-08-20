using Laugh.Life;
using Laugh.Movement;
using Laugh.Shoots;

namespace Laugh.IA.FSM
{
	public class MovementAndShootState : State

	{
		private readonly CanMoveBase canMoveBase;
		private readonly CanShootBase canShootBase;

		public MovementAndShootState(CanMoveBase canMoveBase, CanShootBase canShootBase, State nextState, LifeBase lifeBase): base(nextState, lifeBase) 
		{
			this.canMoveBase = canMoveBase;
			this.canShootBase = canShootBase;
		}
		
		public override void OnStateEnter()
		{
			canMoveBase.CanMove = true; 
			canShootBase.Canfire = true;
		}

		public override void OnStateExit()
		{
			canMoveBase.CanMove = false; 
			canShootBase.Canfire = false;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}