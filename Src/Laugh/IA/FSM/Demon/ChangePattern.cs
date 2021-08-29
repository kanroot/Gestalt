using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class ChangePattern : StateBase
	{

		private CanShootDemon canShootDemon;

		public ChangePattern(CanShootBase canShootDemon)
		{
			this.canShootDemon = (CanShootDemon) canShootDemon;
		}

		public override void OnEnter()
		{
			canShootDemon.Canfire = true;
			canShootDemon.CanRotateNode = false;
		}

		public override void OnExit()
		{
			//canShootDemon.DegreesRotate++;
			canShootDemon.Canfire = false;
			canShootDemon.CanRotateNode = true;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}