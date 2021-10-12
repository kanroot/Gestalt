using Gestalt.IA.Enemy;
using Gestalt.Movements.Enemy;
using Godot;
using Laugh.IA;

namespace Gestalt.IA
{
	public class IAEnemy : IABase
	{
		private ShootNode shootNode;
		private MovementNode movementNode;
		[Export] private NodePath movementNodePath;
		[Export] private NodePath shootNodePath;
		public override void _Ready()
		{
			base._Ready();
			movementNode = GetNode<MovementNode>(movementNodePath);
			shootNode = GetNode<ShootNode>(shootNodePath);
		}
	}
}