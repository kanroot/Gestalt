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
	}
}