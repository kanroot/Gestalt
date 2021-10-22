using Gestalt.Movements.Enemy;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public class StateTwo : StateBaseDemon
	{
		private readonly MovementToPlayer movementToPlayer;
		private readonly PackedScene radius;
		private readonly ShootCircleEnemy shootCircleEnemy;
		private Area2D area2DCollision;
		private CollisionShape2D collisionShape2D;
		private CollisionShape2D entityShape;
		private Timer timerToGrow;
		
		public StateTwo(ShootNode shootNode, MovementNode movementNode, KinematicBody2D entity, PackedScene spawn, PackedScene radius, PackedScene bullet, int countNodes, int speedBullet, int degrees, int direction, int speedMovement) : base(shootNode, movementNode, entity, spawn, bullet, countNodes, speedBullet, degrees, direction, speedMovement)
		{
			shootCircleEnemy = new ShootCircleEnemy(spawn, countNodes, bullet, speedBullet, Entity, direction, degrees);
			movementToPlayer = new MovementToPlayer(Entity, speedMovement);
			this.radius = radius;
		}
		
		public override void OnEnter()
		{
			AddAreaDetect();
			ShootNode.SetPattern(shootCircleEnemy);
			shootCircleEnemy.CreateSpawn();
			MovementNode.SetPattern(movementToPlayer, "StateTwo");
			shootCircleEnemy.CanRotate = true;
			MovementNode.CanMove = false;
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

		private void AddAreaDetect()
		{
			area2DCollision = (Area2D)radius.Instance();
			collisionShape2D = area2DCollision.GetChild<CollisionShape2D>(0);
			entityShape = Entity.GetChild<CollisionShape2D>(0);
			collisionShape2D.Scale = entityShape.Scale;
			collisionShape2D.Shape = entityShape.Shape;
			timerToGrow = area2DCollision.GetChild<Timer>(1);
			Entity.CallDeferred("add_child", area2DCollision);
		}
	}
}