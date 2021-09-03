using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement.Demon;

namespace Laugh.IA.FSM.Demon
{
	public class MoveAttack : StateBase
	{
		private KinematicBody2D entity;
		[Export()] private NodePath entityPath;
		[Export()] public bool CanMove { get; set; }
		[Export()] private float Speed {get; set; }
		private Bounce bounce;
		private MoveToPlayer moveToPlayer;
		
		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			bounce = new Bounce(entity, CanMove, Speed);
			moveToPlayer = new MoveToPlayer(entity, CanMove, Speed);
		}
		
		public override void _Process(float delta)
		{
			bounce.MoveTo(delta);	
		}
		
		public override void OnEnter()
		{
			
		}
		
		



		public override void OnExit()
		{
		}
		
		public override bool ShouldTransition()
		{
			//implementar una señal cuando la vida sea inferior a cierto %
			return true;
		}
	}
}