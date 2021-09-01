using Laugh.IA.FSM.State;
using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class ShootAttack : StateBase

	{
		private readonly CanShootBase canShootBase;


		public ShootAttack(CanShootBase canShootBase)
		{
			this.canShootBase = canShootBase;
		}


		public override void OnEnter()
		{
			canShootBase.CanShoot = true;
		}

		public override void OnExit()
		{
			canShootBase.CanShoot = false;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}