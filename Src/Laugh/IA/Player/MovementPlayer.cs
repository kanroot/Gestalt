using Godot;
using Laugh.TypeOfMovement.Player;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Player
{
	[RegisteredType(nameof(MovementPlayer), "res://logos//hitomi.png", nameof(Node))]
	public class MovementPlayer : Node
	{
		private PlayerMovement movement;
		private KinematicBody2D entity;
		[Export()] private NodePath entityPath;
		[Export()] private float speed;
		[Export()] private bool canMove;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			movement = new PlayerMovement(entity, speed, canMove);
		}

		public override void _Process(float delta)
		{
			movement.DoMovement(delta);
		}
	}
}