using Gestalt.AI.FSM.EnemyStates.Demon;
using Gestalt.AI.FSM.Resources;
using Godot;

namespace Gestalt.Nodes.AINode
{
	public class IADemon : IABoss
	{
		[Export] private DemonState resourceOne;
		[Export] private DemonStateTwo resourceTwo;
		private CollisionShape2D originalFormRadius;

		//Radius of entity
		private Area2D radius;

		public override void _Ready()
		{
			base._Ready();
			LifeBoss.Connect("SecondThird", this, nameof(EnterStateTwo));
			LifeBoss.Connect("DeathBoss", this, nameof(Death));
		}

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
			GetChild();
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
				resourceTwo.CountNodes,
				resourceTwo.SpeedBullet,
				resourceTwo.Degrees,
				resourceTwo.Direction,
				resourceTwo.SpeedMovement
			);
		}
		private void GetChild()
		{
			var children = Entity.GetChildren();
			foreach (var child in children)
			{
				if (!(child is Area2D r)) continue;
				radius = r;
				originalFormRadius = r.GetChild<CollisionShape2D>(0);
			}
			AddConnections();
		}

		private void AddConnections()
		{
			var timer = (Timer) radius.GetChild(1);
			timer.Connect("timeout", this, nameof(GrowAreaDetect));
			radius.Connect("body_entered", this, nameof(OnBodyEntered));
		}


		private void OnBodyEntered(KinematicBody2D body)
		{
			GD.Print(body);
			GD.Print("entre");
			ResetForm();
		}

		private void GrowAreaDetect()
		{
			var collisionShape = (CollisionShape2D) radius.GetChild(0);
			collisionShape.Scale = (collisionShape.Scale * 2);
		}

		private void ResetForm()
		{
			//two.CollisionShape2D.Scale = originalFormRadius.Scale;
		}
		
		
	}
}