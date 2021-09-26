using Godot;
using Laugh.TypeOfMovement;
using Laugh.TypeOfMovement.Enemy;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Enemy
{
	[RegisteredType(nameof(Movement), "res://logos//hitomi.png", nameof(Node))]
	public class Movement : Node
	{
		private MovementBase movementPattern;
		private KinematicBody2D entity;
		[Export()] private NodePath entityPath;
		[Export()] private float speed;
		[Export()] private bool canMove;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			movementPattern = new MovementBounce(entity, speed, canMove);
		}

		public void SetPattern(MovementBase pattern)
		{
			movementPattern = pattern;
		}

		public override void _Process(float delta)
		{
			movementPattern.DoMovement(delta);
		}
	}
}