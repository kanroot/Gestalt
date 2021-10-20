using Gestalt.Movements.Enemy;
using Gestalt.Nodes.AINode;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public class StateTwo : StateBase
	{
		public readonly MovementToPlayer MovementToPlayer;
		private readonly ShootCircleEnemy shootCircleEnemy;
		private readonly PackedScene radius;
		public Timer TimerToGrow;
		public Area2D Area2DCollision;
		public CollisionShape2D CollisionShape2D;
		public StateTwo(
			ShootNode shootNode,
			MovementNode movementNode,
			KinematicBody2D entity,
			PackedScene spawn,
			PackedScene radius,
			PackedScene bullet,
			int countNodes,
			int speedBullet,
			int degrees,
			int direction,
			int speedMovement)
			: base(shootNode, movementNode, entity)
		{
			shootCircleEnemy = new ShootCircleEnemy(spawn, countNodes, bullet, speedBullet, Entity, direction, degrees);
			MovementToPlayer = new MovementToPlayer(Entity, speedMovement);
			this.radius = radius;
		}

		private void AddRadius()
		{
			Area2DCollision = (Area2D) radius.Instance();
			CollisionShape2D = Area2DCollision.GetChild<CollisionShape2D>(0);
			var entityShape = Entity.GetChild<CollisionShape2D>(0);
			CollisionShape2D.Scale = entityShape.Scale;
			CollisionShape2D.Shape = entityShape.Shape;
			TimerToGrow = Area2DCollision.GetChild<Timer>(1);
			Entity.CallDeferred("add_child",Area2DCollision);
		}
		
		public override void OnEnter()
		{
			AddRadius();
			ShootNode.SetPattern(shootCircleEnemy);
			shootCircleEnemy.CreateSpawn();
			MovementNode.SetPattern(MovementToPlayer);
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