using Godot;
using Laugh.IA.Enemy;
using Laugh.TypeOfMovement;
using Laugh.TypeOfShoots;

namespace Laugh.IA.FSM.Enemy
{
	public abstract class StateBase
	{
		protected PackedScene Bullet;
		protected int CountSpawn;
		protected StateBase CurrentState;
		protected int DegreesToRotate;
		protected int DirectionToRotate;
		protected KinematicBody2D Entity;
		protected MovementBase MovementBase;
		protected IA.Enemy.Movement MovementNode;
		protected ShootBase ShootBase;
		protected Shoot ShootNode;
		protected PackedScene SpawnBullet;
		protected float SpeedBullet;

		protected StateBase(Shoot shootNode, IA.Enemy.Movement movementNode, PackedScene spawn, int countSpawn,
			PackedScene bullet, float speedBullet,
			KinematicBody2D entity, int directionToRotation, int degreesRotate)
		{
			ShootNode = shootNode;
			MovementNode = movementNode;
			ShootBase = new ShootCircleEnemy(spawn, countSpawn, bullet, speedBullet, entity, directionToRotation,
				degreesRotate);
		}

		public abstract void OnEnter(
		);

		public abstract void OnExit();
	}
}