using Godot;
using Laugh.IA.FSM.PatternOfShoots;
using Laugh.Movement.Enemy;

namespace Laugh.IA.FSM.State
{
	public class StateOne : Node
	{
		private KinematicBody2D entity;
		private float speedMovement = 500;
		private float speedBullet = 250;
		private BounceMovement bounceMovement;
		private PatternBaseShoot circlePattern;

		//private BounceMovement bounceMovement;
		private PatternBaseShoot pulsePatter;

		public StateOne(KinematicBody2D entity)
		{
			this.entity = entity;
		}
		
		public  void OnEnter()
		{
			bounceMovement = new BounceMovement(entity, true, speedMovement);
			//cambiar la forma de instanciar para el enemigo
			//circlePattern = new PatternBaseShoot(, 20 , 1);
		}

		public void OnExit()
		{
		}
		
	}
}