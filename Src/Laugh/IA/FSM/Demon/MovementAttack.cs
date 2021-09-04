using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement.Demon;

namespace Laugh.IA.FSM.Demon
{
	public class MovementAttack : StateBase
	{
		[Export()] private NodePath entityPath;
		private KinematicBody2D entity;
		private MoveTowardsPlayer moveTowardsPlayer;
		private BounceMovement bounceMovement;
		[Export()] public bool CanMove { get; set; }
		[Export()] private float Speed {get; set; }

		public KinematicBody2D PositionPlayer { set; get; } = new KinematicBody2D();
		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			bounceMovement = new BounceMovement(entity, CanMove, Speed);
			moveTowardsPlayer = new MoveTowardsPlayer(entity, CanMove, Speed);
			entity.Connect("ready", this, nameof(CallMovements));
		}
		
		public override void OnEnter()
		{
			moveTowardsPlayer.UpdatePositionPlayer(PositionPlayer);
			moveTowardsPlayer.CanMove = true;
		}
		

		public override void OnExit()
		{
			bounceMovement.CanMove = true;
		}
		
		public override bool ShouldTransition()
		{
			return true;
		}

		private void CallMovements()
		{
			entity.AddChild(bounceMovement);
			entity.AddChild(moveTowardsPlayer);
		}
	}
}