using Gestalt.Movements.Enemy;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public class StateThree : StateBaseDemon
	{
		private readonly MovementBounce movementBounce;
		private readonly ShootCircleEnemy shootCircleEnemy;

		public StateThree(ShootNode shootNode, MovementNode movementNode, KinematicBody2D entity, PackedScene spawn,
			PackedScene bullet, int countNodes, int speedBullet, int degrees, int direction, int speedMovement) : base(
			shootNode, movementNode, entity, spawn, bullet, countNodes, speedBullet, degrees, direction, speedMovement)
		{
			shootCircleEnemy = new ShootCircleEnemy(spawn, countNodes, bullet, speedBullet, Entity, direction, degrees);
			movementBounce = new MovementBounce(Entity, speedMovement);
		}

		public override void OnEnter()
		{
			ShootNode.SetPattern(shootCircleEnemy);
			MovementNode.SetPattern(movementBounce, "StateOne");
			shootCircleEnemy.CreateSpawn();
			shootCircleEnemy.CanRotate = true;
			MovementNode.CanMove = true;
			ShootNode.TimerToShoot.Autostart = true;
		}

		public override void OnExit()
		{
			ShootNode.TimerToShoot.Autostart = false;
			MovementNode.CanMove = false;
			shootCircleEnemy.CanRotate = false;
			ShootNode.CanShoot = false;
			shootCircleEnemy.KillNodes();
		}
	}
}