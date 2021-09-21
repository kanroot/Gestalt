using Godot;
using Laugh.Shoots;

namespace Laugh.IA.FSM.PatternOfShoots
{
	public abstract class PatternBase : Node
	{
		protected CanShootCircularEnemy CanShootCircularEnemy;
		private readonly int CountOfNodeSpawns;

		public PatternBase(CanShootCircularEnemy canShootCircularEnemy, int countOfNodeSpawns)
		{
			CanShootCircularEnemy = canShootCircularEnemy;
			CountOfNodeSpawns = countOfNodeSpawns;
			CanShootCircularEnemy.KillNodes();
			AssignCountOfSpawns();
		}

		private void AssignCountOfSpawns()
		{
			CanShootCircularEnemy.CountDivisionCircle = CountOfNodeSpawns;
		}
	}
}