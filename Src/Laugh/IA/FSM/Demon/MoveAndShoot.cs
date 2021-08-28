using Laugh.Movement;
using Laugh.Shoots;

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
			canShootBase.Canfire = true;
		}

		public override void OnExit()
		{
			canMoveBase.CanMove = false;
			canShootBase.Canfire = false;
		}

		public override bool ShouldTransition()
		{
			//algun parametro
			return true;
		}
	}
}