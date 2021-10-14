using Gestalt.IA.FSM.EnemyStates.Demon;
using Gestalt.IA.Resources;
using Gestalt.Nodes.EnemyNodes;
using Godot;

namespace Gestalt.IA
{
	public class IAEnemy : IABase
	{
		[Export] private NodePath movementNodePath;
		[Export] private NodePath shootNodePath;
		[Export] private DemonState resourceStateOne;
		private MovementNode movementNode;
		private ShootNode shootNode;
		private StateOne stateOne;

		public override void _Ready()
		{
			base._Ready();
			movementNode = GetNode<MovementNode>(movementNodePath);
			shootNode = GetNode<ShootNode>(shootNodePath);
			BuildStates();
			Entity.Connect("ready", this, nameof(Enter));
		}

		private void Enter()
		{
			stateOne.OnEnter();
		}
		
		private void BuildStates()
		{
			stateOne = new StateOne(
				shootNode,
				movementNode,
				Entity,
				resourceStateOne.Spawn,
				resourceStateOne.Bullet,
				resourceStateOne.CountNodes,
				resourceStateOne.SpeedBullet,
				resourceStateOne.Degrees,
				resourceStateOne.Direction,
				resourceStateOne.SpeedMovement
			);
		}
	}
}