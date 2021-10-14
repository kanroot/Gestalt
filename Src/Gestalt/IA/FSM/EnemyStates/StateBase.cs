using Gestalt.Nodes.EnemyNodes;
using Godot;

namespace Gestalt.IA.FSM.EnemyStates
{
	public abstract class StateBase
	{
		protected MovementNode MovementNode;
		protected ShootNode ShootNode;
		protected KinematicBody2D Entity;
		protected StateBase(ShootNode shootNode, MovementNode movementNode , KinematicBody2D entity)
		{
			ShootNode = shootNode;
			MovementNode = movementNode;
			Entity = entity;
		}

		public abstract void OnEnter();
		public abstract void OnExit();
	}
}