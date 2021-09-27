using Laugh.Shoots.ConductOfShoots;

namespace Laugh.TypeOfShoots.ConductOfShoots
{
	public class ShootEnemy : Shoot
	{
		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			BulletFree.Autostart = true;
		}


		public override void _PhysicsProcess(float delta)
		{
			Position += Transform.x * SpeedBullet * delta;
		}
	}
}