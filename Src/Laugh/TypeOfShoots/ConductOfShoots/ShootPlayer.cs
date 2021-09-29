using Godot;
using Laugh.Shoots.ConductOfShoots;

namespace Laugh.TypeOfShoots.ConductOfShoots
{
	public class ShootPlayer : Shoot
	{
		private Vector2 Movement { get; set; }
		private Vector2 MousePosition { get; set; }
		public float Damage { get; set; }

		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			MousePosition = GetLocalMousePosition();
			Damage = 10;
		}

		public override void _PhysicsProcess(float delta)
		{
			Movement = Movement.MoveToward(MousePosition, delta);
			Movement = Movement.Normalized() * SpeedBullet;
			Position += Movement;
		}
	}
}