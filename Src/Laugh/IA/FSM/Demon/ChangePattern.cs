using Laugh.IA.FSM.State;
using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class ChangePattern : StateBase
	{
		private readonly CanShootDemon canShootDemon;
		private float originalSpeedBullet;

		//cada patron de disparo que sea una clase independiente y change pattern tenga referencias a ellas
		//changePatter decide cual seleccionar
		public ChangePattern(CanShootBase canShootDemon)
		{
			this.canShootDemon = (CanShootDemon)canShootDemon;
			originalSpeedBullet = this.canShootDemon.SpeedBullet;
		}

		public override void OnEnter()
		{
			canShootDemon.KillNodes();
			canShootDemon.CanShoot = true;
			canShootDemon.CanRotateNode = true;
		}

		public override void OnExit()
		{
			//canShootDemon.DegreesRotate++;
			canShootDemon.CanShoot = false;
			canShootDemon.CanRotateNode = true;
		}

		public void ChangePatterns()
		{
			canShootDemon.KillNodes();
			SpaceInvadersPattern();
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
			canShootDemon.SpeedBullet *= 2;
			canShootDemon.CountDivisionCircle = 4;
			canShootDemon.DegreesRotate = 2;
		}

		public override bool ShouldTransition()
		{
			return true;
		}
	}
}