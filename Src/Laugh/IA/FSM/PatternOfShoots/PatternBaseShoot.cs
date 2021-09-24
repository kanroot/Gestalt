using Godot;
using Laugh.Shoots.CanShoots;


namespace Laugh.IA.FSM.PatternOfShoots
{
	public class PatternBaseShoot
	{
		private readonly int CountOfNodeSpawns;
		private readonly float factor;
		protected EnemyCircle EnemyCircle;

		public PatternBaseShoot(int countOfNodeSpawns, float factor, PackedScene bulletSpawn, bool thisCanShoot,
			KinematicBody2D entity,
			PackedScene bulletScene)
		{
			CountOfNodeSpawns = countOfNodeSpawns;
			this.factor = factor;
			EnemyCircle = new EnemyCircle();
			entity.AddChild(EnemyCircle);
			EnemyCircle.CountDivisionCircle = CountOfNodeSpawns;
			EnemyCircle.SpeedBullet = 2000;
		}

		public void GenerateNodes()
		{
			EnemyCircle.AddNodeSpawnBullet();
		}
	}
}