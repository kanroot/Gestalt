using Laugh.IA.FSM.State;
using Laugh.Movement;
using Laugh.Shoots;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA.FSM.Demon
{
	public class MoveAndShoot : StateBase
	{
		private readonly CanMoveBase canMoveBase;
		private readonly CanShootBase canShootBase;

		public MoveAndShoot(CanMoveBase canMoveBase, CanShootBase canShootBase)
		{
			this.canMoveBase = canMoveBase;
			this.canShootBase = canShootBase;
		}


		public override void OnEnter()
		{
			canMoveBase.CanMove = true;
			canShootBase.CanShoot = true;
		}

		public override void OnExit()
		{
			canMoveBase.CanMove = false;
			canShootBase.CanShoot = false;
		}

		public override bool ShouldTransition()
		{
			//algun parametro
			return true;
		}
	}
}