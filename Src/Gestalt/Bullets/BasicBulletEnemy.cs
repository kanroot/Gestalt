using Godot;

namespace Gestalt.Bullets
{
	public class BasicBulletEnemy : BulletBase
	{
		private Sprite bulletBody;
		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			BulletFree.Autostart = true;
			bulletBody = GetChild<Sprite>(0);
		}


		public override void _PhysicsProcess(float delta)
		{
			Position += Transform.x * SpeedBullet * delta;
			bulletBody.RotationDegrees += 1;
		}
	}
}