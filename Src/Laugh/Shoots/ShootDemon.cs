using Godot;

namespace Laugh.Shoots
{
	public class ShootDemon : Shoot
	{
		
		private Vector2 movement;
		
		public Vector2 Direction { get; set; }
		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			BulletFree.Autostart = true;
		}

		
		public override void _PhysicsProcess(float delta)
		{
			movement = movement.MoveToward(Direction, delta);
			movement = movement.Normalized() * SpeedBullet;
			Position += movement;
		}
	}
}