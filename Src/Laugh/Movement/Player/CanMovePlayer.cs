using Godot;

namespace Laugh.Movement
{
	public class CanMovePlayer : Node
	{
		[Export] private NodePath entityPath;
		private KinematicBody2D entity;
		[Export] public bool CanMove { set; get; } = true;
		[Export] public int Speed { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
		}

		public override void _Process(float delta)
		{
			if (CanMove != true) return;
			entity.MoveAndSlide(GetInputMovement());
		}

		private Vector2 GetInputMovement()
		{
			var directionPlayerVector = new Vector2();

			if (Input.IsActionPressed("ui_right"))
				directionPlayerVector.x += 1;

			if (Input.IsActionPressed("ui_left"))
				directionPlayerVector.x -= 1;

			if (Input.IsActionPressed("ui_down"))
				directionPlayerVector.y = 1;

			if (Input.IsActionPressed("ui_up"))
				directionPlayerVector.y -= 1;

			return directionPlayerVector * Speed;
		}

	
	}
}