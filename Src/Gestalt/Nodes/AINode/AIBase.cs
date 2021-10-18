using Gestalt.Nodes.EnemyNodes;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public abstract class AIBase : Node
	{
		protected MovementNode MovementNode;
		[Export] private NodePath movementNodePath;
		protected ShootNode ShootNode;
		[Export] private NodePath shootNodePath;
		protected abstract void BuildStates();
		protected abstract void EnterStateOne();
		protected abstract void EnterStateTwo();
		protected abstract void EnterStateThree();
	}
}