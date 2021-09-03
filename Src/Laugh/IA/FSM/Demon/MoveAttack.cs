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

		public override void _Ready()
		{
			

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
		
		public override bool ShouldTransition()
		{
			//implementar una señal cuando la vida sea inferior a cierto %
			return true;
		}
	}
}