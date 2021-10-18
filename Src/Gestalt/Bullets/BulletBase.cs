using Godot;

namespace Gestalt.Bullets
{
	public class BulletBase : Area2D
	{
		public float SpeedBullet { get; set; }
		protected Timer BulletFree { get; set; } = new Timer();

		[Export] public float Damage { get; set; }

		private void _on_Shoot_body_entered(Node2D node2D)
		{
			BulletFree.QueueFree();
			QueueFree();
		}

		private void _on_BulletFree_timeout()
		{
			BulletFree.QueueFree();
			QueueFree();
		}
	}
}