using Gestalt.Movements.Enemy;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public class StateOne : StateBase
	{
		private readonly MovementBounce movementBounce;
		private readonly ShootCircleEnemy shootCircleEnemy;

		public StateOne(
			ShootNode shootNode,
			MovementNode movementNode,
			KinematicBody2D entity,
			PackedScene spawn,
			PackedScene bullet,
			int countNodes,
			int speedBullet,
			int degrees,
			int direction,
			int speedMovement
		) : base(shootNode, movementNode, entity)

		{
			shootCircleEnemy = new ShootCircleEnemy(spawn, countNodes, bullet, speedBullet, Entity, direction, degrees);
			movementBounce = new MovementBounce(Entity, speedMovement);
		}

		public override void OnEnter()
		{
			ShootNode.SetPattern(shootCircleEnemy);
			MovementNode.SetPattern(movementBounce);
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