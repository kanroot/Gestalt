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
		public CollisionShape2D EntityShape;
		private Timer timerToGrow;
		private Area2D area2DCollision;
		private CollisionShape2D collisionShape2D;

		public StateTwo(
			ShootNode shootNode,
			MovementNode movementNode,
			KinematicBody2D entity,
			PackedScene spawn,
			PackedScene radius,
			PackedScene bullet,
			float scaleOfDetectArea,
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

		private void AddRadius()
		{
			area2DCollision = (Area2D)radius.Instance();
			collisionShape2D = area2DCollision.GetChild<CollisionShape2D>(0);
			EntityShape = Entity.GetChild<CollisionShape2D>(0);
			collisionShape2D.Scale = EntityShape.Scale;
			collisionShape2D.Shape = EntityShape.Shape;
			timerToGrow = area2DCollision.GetChild<Timer>(1);
			Entity.CallDeferred("add_child",area2DCollision);
		}

		public Area2D GetChild()
		{
			var children = Entity.GetChildren();
			foreach (var child in children)
			{
				if (!(child is Area2D r)) continue;
				return r;
			}
			return new Area2D();
		}
	}
}