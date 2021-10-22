using Gestalt.Movements.Enemy;
using Gestalt.Nodes.EnemyNodes;
using Gestalt.Shoots;
using Godot;

namespace Gestalt.AI.FSM.EnemyStates.Demon
{
	public abstract class StateBaseDemon : StateBase
	{
		protected StateBaseDemon(
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
			
		}

		public abstract override void OnEnter();
		public abstract override void OnExit();
	}
}