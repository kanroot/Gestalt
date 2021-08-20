using Laugh.Life;
using Laugh.Shoots;

namespace Laugh.IA.FSM
{
	public class ShootAttackState : State
	{
		private readonly CanShootBase canShootBase;

		public ShootAttackState(CanShootBase canShootBase, State nextState, LifeBase lifeBase): base(nextState, lifeBase) 
		{
			this.canShootBase = canShootBase;
		}
		
		
		public override void OnStateEnter()
		{
			canShootBase.Canfire = true;
		}

		public override void OnStateExit()
		{
			canShootBase.Canfire = false;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}