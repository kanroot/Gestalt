using Gestalt.AI.FSM.EnemyStates;
using Gestalt.Life;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public abstract class IABoss : AIBase
	{
		protected int Counter;
		protected LifeBoss LifeBoss;
		[Export] protected NodePath LifePath;
		protected StateBase StateOne;
		protected StateBase StateTwo;

		public override void _Ready()
		{
			base._Ready();
			LifeBoss = GetNode<LifeBoss>(LifePath);
			BuildStates();
			EnterStateOne();
		}

		protected void Death()
		{
			Entity.QueueFree();
		}
	}
}