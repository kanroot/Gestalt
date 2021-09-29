using Godot;
using Laugh.IA.Enemy;
using Laugh.Movements.Enemy;

namespace Laugh.IA
{
	public class IAEnemy : IABase
	{
		private MovementToPlayer movementBase;
		private MovementNode movementNode;
		[Export] private NodePath movementNodePath;

		public override void _Ready()
		{
			base._Ready();
			movementBase = new MovementToPlayer(entity, 2000, true);
			movementNode = GetNode<MovementNode>(movementNodePath);
		}
	}
}