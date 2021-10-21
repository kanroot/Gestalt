using Gestalt.AI.FSM.EnemyStates.Demon;
using Gestalt.AI.FSM.Resources;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public class IADemon : IABoss
	{
		[Export] private DemonState resourceOne;
		[Export] private DemonStateTwo resourceTwo;

		//Radius of second state
		private StateTwo stateTwo;
		private Area2D detectArea2D;
		private CollisionShape2D areaDetect;
		private Timer growingTimer;

		public override void _Ready()
		{
			base._Ready();
			LifeBoss.Connect("SecondThird", this, nameof(EnterStateTwo));
			//LifeBoss.Connect("FirstThird", this, nameof(EnterStateTwo));
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
			GetAreaDetect();
			Counter += 1;
		}

		protected override void EnterStateThree()
		{
			if (Counter != 2) return;
			StateTwo.OnExit();
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
				resourceTwo.ScaleOfAreaDetect,
				resourceTwo.CountNodes,
				resourceTwo.SpeedBullet,
				resourceTwo.Degrees,
				resourceTwo.Direction,
				resourceTwo.SpeedMovement
			);
			stateTwo = (StateTwo)StateTwo;
		}
		
		//segundo estado
		private void GetAreaDetect()
		{
			detectArea2D = stateTwo.GetChild();
			areaDetect = detectArea2D.GetChild<CollisionShape2D>(0);
			growingTimer = (Timer) detectArea2D.GetChild(1);
			AddConnections();
		}

		private void AddConnections()
		{
			growingTimer.Connect("timeout", this, nameof(GrowAreaDetect));
			detectArea2D.Connect("body_entered", this, nameof(OnBodyEntered));
		}


		private void OnBodyEntered(KinematicBody2D player)
		{
			if (!player.IsInGroup("player")) return;
			stateTwo.MovementToPlayer.UpdatePositionPlayer(player);
			ResetForm();
		}

		private void GrowAreaDetect()
		{
			areaDetect.Scale *= resourceTwo.ScaleOfAreaDetect;
		}

		private void ResetForm()
		{
			areaDetect.Scale = stateTwo.EntityShape.Scale;
		}
		
		
	}
}