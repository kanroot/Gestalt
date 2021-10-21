using Gestalt.Movements;
using Gestalt.Movements.Enemy;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.Nodes.EnemyNodes
{
	[RegisteredType(nameof(MovementNode))]
	public class MovementNode : Node
	{
		private CollisionShape2D areaDetect;
		private Area2D detectArea2D;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private Timer growingTimer;
		private MovementBase movementPattern;
		[Export] public bool CanMove { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public void SetPattern(MovementBase pattern)
		{
			movementPattern = pattern;
		}

		public void SetPattern(MovementBase pattern, string stateBase)
		{
			switch (stateBase)
			{
				case "StateOne":
					movementPattern = pattern;
					break;
				case "StateTwo":
					movementPattern = pattern;
					GetAreaDetect();
					break;
				case "StateThree":
					movementPattern = pattern;
					break;
			}
		}

		public override void _Process(float delta)
		{
			if (CanMove == false) return;
			movementPattern.DoMovement(delta);
		}


		//comportamiento para el estado dos
		private void GetAreaDetect()
		{
			detectArea2D = GetRadiusDetect();
			areaDetect = detectArea2D.GetChild<CollisionShape2D>(0);
			growingTimer = (Timer)detectArea2D.GetChild(1);
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
			CanMove = true;
			var a = (MovementToPlayer)movementPattern;
			a.UpdatePositionPlayer(player);
			ResetForm();
		}

		private Area2D GetRadiusDetect()
		{
			var children = entity.GetChildren();
			foreach (var child in children)
			{
				if (!(child is Area2D r)) continue;
				return r;
			}

			return new Area2D();
		}

		private void GrowAreaDetect()
		{
			areaDetect.Scale *= (float)1.5;
		}

		private void ResetForm()
		{
			areaDetect.Scale = new Vector2(1, 1);
		}
	}
}