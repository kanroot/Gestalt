using Gestalt.Movements;
using Gestalt.Movements.Enemy;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.IA.Enemy
{
	[RegisteredType(nameof(MovementNode), nameof(Node))]
	public class MovementNode : Node
	{
		[Export] private bool CanMove { get; set; }
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private MovementBase movementPattern;


		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public void SetPattern(MovementBase pattern)
		{
			movementPattern = pattern;
		}

		public override void _Process(float delta)
		{
			if (CanMove == false) return;
			movementPattern.DoMovement(delta);
		}
	}
}