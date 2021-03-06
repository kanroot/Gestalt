using Godot;

namespace Gestalt.Bullets
{
	public class BasicBulletPlayer : BulletBase
	{
		private Vector2 Movement { get; set; }
		private Vector2 MousePosition { get; set; }

		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			MousePosition = GetLocalMousePosition();
		}

		public override void _PhysicsProcess(float delta)
		{
			Movement = Movement.MoveToward(MousePosition, delta);
			Movement = Movement.Normalized() * SpeedBullet;
			Position += Movement;
		}
	}
}