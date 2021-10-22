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
		private MovementToPlayer movementToPlayer;
		[Export] public bool CanMove { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public override void _Process(float delta)
		{
			if (CanMove == false) return;
			movementPattern.DoMovement(delta);
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
					movementToPlayer = (MovementToPlayer)movementPattern;
					GetAreaDetect();
					break;
				case "StateThree":
					movementPattern = pattern;
					break;
			}
		}

		//comportamiento para el estado dos,
		//existe un problema con el connect, es imposible usarlo en clases puras de c#
		//No encuentra las referencia a los metodos movementToPlayer.GrowAreaDetect a pesar de que se emite la señal
		//realice una especie de puente

		private void GetAreaDetect()
		{
			detectArea2D = GetRadiusDetect();
			movementToPlayer.AreaDetect = detectArea2D;
			areaDetect = detectArea2D.GetChild<CollisionShape2D>(0);
			growingTimer = (Timer)detectArea2D.GetChild(1);
			AddConnections();
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

		private void AddConnections()
		{
			growingTimer.Connect("timeout", this, nameof(GrowAreaDetect));
			detectArea2D.Connect("body_entered", this, nameof(OnBodyEntered));
		}


		private void OnBodyEntered(KinematicBody2D player)
		{
			CanMove = movementToPlayer.OnBodyEntered(player);
		}


		private void GrowAreaDetect()
		{
			movementToPlayer.GrowAreaDetect();
		}

		private void ResetForm()
		{
			movementToPlayer.ResetForm();
		}
	}
}