using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement.Enemy;

namespace Laugh.IA.FSM.PatternOfMovement
{
	public class MoveToPlayer : StateBase
	{
		private BounceMovement bounceMovement;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private MoveTowardsPlayer moveTowardsPlayer;
		[Export] public bool CanMove { get; set; }
		[Export] private float Speed { get; set; }
		
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
			throw new System.NotImplementedException();
		}

		public override void OnExit()
		{
			throw new System.NotImplementedException();
		}

		public override bool ShouldTransition()
		{
			throw new System.NotImplementedException();
		}
		private void CallMovements()
		{
			entity.AddChild(bounceMovement);
			entity.AddChild(moveTowardsPlayer);
		}
		
	}
}