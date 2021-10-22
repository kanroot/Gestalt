using Gestalt.AI.FSM.EnemyStates.Demon;
using Gestalt.AI.FSM.Resources;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public class IADemon : IABoss
	{
		private CollisionShape2D areaDetect;
		private Area2D detectArea2D;
		private Timer growingTimer;
		
		[Export] private DemonState resourceOne;
		[Export] private DemonStateTwo resourceTwo;
		[Export] private DemonStateThree resourceThree;

		//Radius of second state
		private StateTwo stateTwo;

		public override void _Ready()
		{
			base._Ready();
			LifeBoss.Connect("SecondThird", this, nameof(EnterStateTwo));
			LifeBoss.Connect("FirstThird", this, nameof(EnterStateThree));
			LifeBoss.Connect("DeathBoss", this, nameof(Death));
		}

		//por defecto se entra en el estado uno
		protected override void EnterStateOne()
		{
			if (Counter != 0) return;
			StateOne.OnEnter();
			Counter += 1;
		}

		protected override void EnterStateTwo()
		{
			if (Counter != 1) return;
			StateOne.OnExit();
			StateTwo.OnEnter();
			Counter += 1;
		}

		protected override void EnterStateThree()
		{
			if (Counter != 2) return;
			StateTwo.OnExit();
			StateThree.OnEnter();
			Counter += 1;
		}

		protected override void BuildStates()
		{
			StateOne = new StateOne(
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

			StateTwo = new StateTwo(
				NodeShoot,
				NodeMovement,
				Entity,
				resourceTwo.Spawn,
				resourceTwo.Radius,
				resourceTwo.Bullet,
				resourceTwo.CountNodes,
				resourceTwo.SpeedBullet,
				resourceTwo.Degrees,
				resourceTwo.Direction,
				resourceTwo.SpeedMovement
			);

			StateThree = new StateThree(
				NodeShoot,
				NodeMovement,
				Entity,
				resourceThree.Spawn,
				resourceThree.Bullet,
				resourceThree.CountNodes,
				resourceThree.SpeedBullet,
				resourceThree.Degrees,
				resourceThree.Direction,
				resourceThree.SpeedMovement
			);
			
			stateTwo = (StateTwo)StateTwo;
		}
	}
}