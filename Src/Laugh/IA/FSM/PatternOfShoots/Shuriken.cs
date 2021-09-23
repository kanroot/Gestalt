using Laugh.Shoots;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA.FSM.PatternOfShoots
{
	public class Shuriken : PatternBaseShoot
	{
		private readonly int rotation;
		
		public Shuriken(int rotation, CanShootCircularEnemy canShootCircularEnemy, int countOfNodeSpawns, float factor) : base(
			canShootCircularEnemy, countOfNodeSpawns, factor)
		{
			this.rotation = rotation;
			ChangeDirectionNode();
			ChangeDegreesRotation();
		}

		private void ChangeDirectionNode()
		{
			CanShootCircularEnemy.DirectionToRotation *= -1;
		}

		private void ChangeDegreesRotation()
		{
			CanShootCircularEnemy.DegreesRotate = rotation;
		}
	}
}
