using Godot;
using Laugh.Shoots;

namespace Laugh.IA.FSM.PatternOfShoots
{
	public abstract class PatternBase : Node
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
		}

		private void AssignCountOfSpawns()
		{
			CanShootCircularEnemy.CountDivisionCircle = CountOfNodeSpawns;
		}

		private void SpeedUpOrDown()
		{
			CanShootCircularEnemy.SpeedBullet *= factor;
		}
	}
}