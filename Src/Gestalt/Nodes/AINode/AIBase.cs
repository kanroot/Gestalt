using Gestalt.Life;
using Gestalt.Nodes.EnemyNodes;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public abstract class AIBase : Node
	{
		protected MovementNode NodeMovement;
		[Export] private NodePath movementNodePath;
		protected ShootNode NodeShoot;
		[Export] private NodePath shootNodePath;
		[Export] private NodePath entityPath;
		private protected KinematicBody2D Entity;

		public override void _Ready()
		{
			NodeMovement = GetNode<MovementNode>(movementNodePath);
			NodeShoot = GetNode<ShootNode>(shootNodePath);
			Entity = GetNode<KinematicBody2D>(entityPath);
		}

		protected abstract void BuildStates();
		protected abstract void EnterStateOne();
		protected abstract void EnterStateTwo();
		protected abstract void EnterStateThree();
	}
}