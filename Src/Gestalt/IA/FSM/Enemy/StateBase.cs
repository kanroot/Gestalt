using Gestalt.IA.Enemy;
using Godot;

namespace Gestalt.IA.FSM.Enemy
{
	public abstract class StateBase
	{
		protected MovementNode NodeMovement = new MovementNode();
		protected ShootNode NodeShoot = new ShootNode();

		protected StateBase(NodePath shootPath, NodePath movementPath, PackedScene spawn, int countSpawn,
			PackedScene bullet, float speedBullet,
			KinematicBody2D entity, int directionToRotation, int degreesRotate)
		{
			NodeShoot = NodeShoot.GetNode<ShootNode>(shootPath);
			NodeMovement = NodeMovement.GetNode<MovementNode>(movementPath);
		}


		public abstract void OnEnter();
		public abstract void OnExit();
	}
}