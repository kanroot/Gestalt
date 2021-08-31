using Laugh.IA.FSM.State;
using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class ChangePattern : StateBase
	{
		private readonly CanShootDemon canShootDemon;
		
		public ChangePattern(CanShootBase canShootDemon)
		{
			this.canShootDemon = (CanShootDemon)canShootDemon;
		}

		public override void OnEnter()
		{
			canShootDemon.Canfire = true;
			canShootDemon.CanRotateNode = true;
		}

		public override void OnExit()
		{
			//canShootDemon.DegreesRotate++;
			canShootDemon.Canfire = false;
			canShootDemon.CanRotateNode = true;
		}

		public void ChangePatterns()
		{
			canShootDemon.KillNodes();
			PulsePattern();
			canShootDemon.AddNodeSpawnBullet();
		}

		private void InvertRotary()
		{
			canShootDemon.DirectionToRotation *= -1;
		}

		private void PulsePattern()
		{
			canShootDemon.CountDivisionCircle = 20;
		}

		private void SpaceInvadersPattern()
		{
			canShootDemon.CountDivisionCircle = 4;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}