using Godot;
using Laugh.Shoots;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA.FSM.PatternOfShoots
{
	public class PatternBase : Node
	{
		private readonly int CountOfNodeSpawns;
		private readonly float factor;
		protected CanShootCircularEnemy CanShootCircularEnemy;

		protected PatternBase(CanShootCircularEnemy canShootCircularEnemy, int countOfNodeSpawns, float factor)
		{
			CanShootCircularEnemy = canShootCircularEnemy;
			CountOfNodeSpawns = countOfNodeSpawns;
			this.factor = factor;
			CanShootCircularEnemy.KillNodes();
			AssignCountOfSpawns();
			SpeedUpOrDown();
			CanShootCircularEnemy.AddNodeSpawnBullet();
		}

		private void AssignCountOfSpawns()
		{
			CanShootCircularEnemy.CountDivisionCircle = CountOfNodeSpawns;
		}

		protected void SpeedUpOrDown()
		{
			CanShootCircularEnemy.SpeedBullet *= factor;
		}
	}
}