using Gestalt.Movements.Enemy;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public class StateTwo : StateBase
	{
		private readonly MovementToPlayer movementToPlayer;
		private readonly ShootCircleEnemy shootCircleEnemy;

		public StateTwo(
			ShootNode shootNode,
			MovementNode movementNode,
			KinematicBody2D entity,
			PackedScene spawn,
			PackedScene bullet,
			int countNodes,
			int speedBullet,
			int degrees,
			int direction,
			int speedMovement)
			: base(shootNode, movementNode, entity)
		{
			shootCircleEnemy = new ShootCircleEnemy(spawn, countNodes, bullet, speedBullet, Entity, direction, degrees);
			movementToPlayer = new MovementToPlayer(Entity, speedMovement);
			ShootNode.TimerToShoot.Autostart = true;
		}

		public override void OnEnter()
		{
			ShootNode.SetPattern(shootCircleEnemy);
			shootCircleEnemy.CreateSpawn();
			MovementNode.SetPattern(movementToPlayer);
			shootCircleEnemy.CanRotate = true;
			MovementNode.CanMove = true;
		}

		public override void OnExit()
		{
			MovementNode.CanMove = false;
			shootCircleEnemy.CanRotate = false;
			ShootNode.CanShoot = false;
			shootCircleEnemy.KillNodes();
		}
	}
}