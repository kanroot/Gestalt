using System;
using Gestalt.AI.FSM.EnemyStates.Demon;
using Gestalt.AI.FSM.Resources;
using Gestalt.Life;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public class IABoss : AIBase
	{
		private LifeBoss lifeBoss;
		[Export] private NodePath lifePath;
		[Export] private DemonState resourceOne;
		[Export] private DemonState resourceTwo;
		private StateOne stateOne;
		private StateTwo stateTwo;
		private int counter = 0;
		public override void _Ready()
		{
			base._Ready();
			lifeBoss = GetNode<LifeBoss>(lifePath);
			BuildStates();
			EnterStateOne();
			lifeBoss.Connect("SecondThird", this, nameof(EnterStateTwo));
			lifeBoss.Connect("DeathBoss", this, nameof(Death));
		}


		protected override void EnterStateOne()
		{
			if (counter != 0) return;
			stateOne.OnEnter();
			counter += 1;

		}

		protected override void EnterStateTwo()
		{
			if (counter != 1) return;
			stateOne.OnExit();
			stateTwo.OnEnter();
			counter += 1;
		}

		protected override void EnterStateThree()
		{
			if (counter != 2) return;
			stateTwo.OnExit();
			counter += 1;
		}

		private void Death()
		{
			Entity.QueueFree();
		}

		protected override void BuildStates()
		{
			stateOne = new StateOne(
				NodeShoot,
				NodeMovement,
				Entity,
				resourceOne.Spawn,
				resourceOne.Bullet,
				resourceOne.CountNodes,
				resourceOne.SpeedBullet,
				resourceOne.Degrees,
				resourceOne.Direction,
				resourceOne.SpeedMovement
			);

			stateTwo = new StateTwo(
				NodeShoot,
				NodeMovement,
				Entity,
				resourceTwo.Spawn,
				resourceTwo.Bullet,
				resourceTwo.CountNodes,
				resourceTwo.SpeedBullet,
				resourceTwo.Degrees,
				resourceTwo.Direction,
				resourceTwo.SpeedMovement
			);
		}
	}
}