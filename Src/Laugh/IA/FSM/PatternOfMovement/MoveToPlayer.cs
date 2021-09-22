using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement.Enemy;

namespace Laugh.IA.FSM.PatternOfMovement
{
	public class MoveToPlayer : PatternBase
	{
		private MoveTowardsPlayer moveTowardsPlayer;
		private bool canMove;
		private float speed;
		public KinematicBody2D PositionPlayer { set; get; } = new KinematicBody2D();
		
		public MoveToPlayer(KinematicBody2D entity, bool canMove, float speed) : base(entity)
		{
			this.canMove = canMove; 
			this.speed = speed;
			entity.Connect("ready", this, nameof(AddChild));
			moveTowardsPlayer = new MoveTowardsPlayer(entity, canMove, speed);
		}
		public void CallMovement()
		{
			moveTowardsPlayer.UpdatePositionPlayer(PositionPlayer);
		}
		
		private void AddChild()
		{
			entity.AddChild(moveTowardsPlayer);
		}


	}
}