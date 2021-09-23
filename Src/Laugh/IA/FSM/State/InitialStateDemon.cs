using Godot;
using Laugh.Movement.Enemy;

namespace Laugh.IA.FSM.State
{
	public class StateOne : Node
	{
		private KinematicBody2D entity;
		private float speedMovement = 500;
		private float speedBullet = 250;

		//private BounceMovement bounceMovement;
		private PatternBase pulsePatter;

		public StateOne(KinematicBody2D entity)
		{
			this.entity = entity;
		}
		
		public  void OnEnter()
		{
			//bounceMovement = new BounceMovement(entity, true, speedMovement);
		}

		public void OnExit()
		{
		}
		
	}
}