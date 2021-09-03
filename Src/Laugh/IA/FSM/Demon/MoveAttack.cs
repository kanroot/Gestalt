using Godot;
using Laugh.IA.FSM.State;
using Laugh.Movement;

namespace Laugh.IA.FSM.Demon
{
	public class MoveAttack : StateBase
	{
		private readonly CanMoveDemon canMoveDemon;

		public MoveAttack(CanMoveDemon canMoveDemon)
		{
			this.canMoveDemon = canMoveDemon;
		}

		public override void OnEnter()
		{
			canMoveDemon.CanMove = true;
		}

		public override void OnExit()
		{
			canMoveDemon.CanMove = false;
		}

		private void SpeedUp()
		{
			canMoveDemon.Speed *= 2;
		}


		public void AttackPlayer(Node2D player)
		{
			canMoveDemon.CanChangeMovement = true;
			canMoveDemon.UpdatePositionPlayer(player);
		}

		public override bool ShouldTransition()
		{
			//implementar una señal cuando la vida sea inferior a cierto %
			return true;
		}
	}
}