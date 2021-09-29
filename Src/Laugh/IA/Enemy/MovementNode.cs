using Godot;
using Laugh.Movements.Enemy;
using Laugh.TypeOfMovement;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Enemy
{
	[RegisteredType(nameof(MovementNode), "res://logos//hitomi.png", nameof(Node))]
	public class MovementNode : Node
	{
		[Export] private bool canMove;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private MovementBase movementPattern;
		[Export] private float speed;

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