using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement.Demon;

namespace Laugh.IA.FSM.Demon
{
	public class MoveAttack : StateBase
	{
		private Bounce bounce;
		private KinematicBody2D entity;
		[Export()] private NodePath entityPath;
		private MoveToPlayer moveToPlayer;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			bounce = new Bounce();
			moveToPlayer = new MoveToPlayer();
		}

		public override void OnEnter()
		{
			
		}

		public override void _Process(float delta)
		{
			
		}

		public override void OnExit()
		{
		}


		public void AttackPlayer(Node2D player)
		{
			moveToPlayer.CanMove = true;
			moveToPlayer.UpdatePositionPlayer(player);
		}

		public override bool ShouldTransition()
		{
			//implementar una señal cuando la vida sea inferior a cierto %
			return true;
		}
	}
}