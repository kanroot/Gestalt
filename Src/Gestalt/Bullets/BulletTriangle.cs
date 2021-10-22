using System;
using Godot;

namespace Gestalt.Bullets
{
	public class BulletTriangle : BasicBulletEnemy
	{
		private Sprite bodyBullet;
		private float radiants;

		public override void _Ready()
		{
			GetTree().Root.AddChild(BulletFree);
			BulletFree.Autostart = true;
			bodyBullet = GetChild<Sprite>(0);
			radiants = (float)(Math.PI / 180 * 1);
		}


		public override void _PhysicsProcess(float delta)
		{
			bodyBullet.Rotate(radiants);
			Position += Transform.x * SpeedBullet * delta;
		}
	}
}