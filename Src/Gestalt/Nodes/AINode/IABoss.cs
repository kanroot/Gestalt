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

		public override void _Ready()
		{
			base._Ready();
			lifeBoss = GetNode<LifeBoss>(lifePath);
			BuildStates();
			lifeBoss.Connect("FirstThird", this, nameof(EnterStateOne));
			lifeBoss.Connect("SecondThird", this, nameof(EnterStateTwo));
		}


		protected override void EnterStateOne()
		{
			stateOne.OnEnter();
		}

		protected override void EnterStateTwo()
		{
			stateOne.OnExit();
			stateTwo.OnEnter();
		}

		protected override void EnterStateThree()
		{
			throw new NotImplementedException();
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
				resourceOne.Spawn,
				resourceOne.Bullet,
				resourceOne.CountNodes,
				resourceOne.SpeedBullet,
				resourceOne.Degrees,
				resourceOne.Direction,
				resourceOne.SpeedMovement
			);
		}
	}
}