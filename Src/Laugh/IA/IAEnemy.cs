using Godot;
using Laugh.Movement.Enemy;

namespace Laugh.IA.Enemy
{
	public class IAEnemy : IABase
	{
		private MovementToPlayer movementBase;
		private Movement movementNode;
		[Export] private NodePath movementNodePath;

		public override void _Ready()
		{
			base._Ready();
			movementBase = new MovementToPlayer(entity, 2000, true);
			movementNode = GetNode<Movement>(movementNodePath);
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
			movementBase.UpdatePositionPlayer(player);
			movementNode.SetPattern(movementBase);
			ResetShapeSize();
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
		}
	}
}