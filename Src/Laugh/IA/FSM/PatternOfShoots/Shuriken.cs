using Godot;
using Laugh.Shoots;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA.FSM.PatternOfShoots
{
	public class Shuriken : PatternBaseShoot
	{
		private readonly int rotation;


		private void ChangeDirectionNode()
		{
			EnemyCircle.DirectionToRotation *= -1;
		}

		private void ChangeDegreesRotation()
		{
			EnemyCircle.DegreesRotate = rotation;
		}

		public Shuriken(int countOfNodeSpawns, float factor, PackedScene bulletSpawn, bool thisCanShoot,
			NodePath timerPath, KinematicBody2D entity, PackedScene bulletScene) : base(countOfNodeSpawns, factor,
			bulletSpawn, thisCanShoot, entity, bulletScene)
		{
			rotation = rotation;
			ChangeDirectionNode();
			ChangeDegreesRotation();
		}
	}
}