using Godot;

namespace Gestalt.Bullets
{
	public class BulletBase : Area2D
	{
		public float SpeedBullet { get; set; }
		protected Timer BulletFree { get; set; } = new Timer();

		//daño, el daño sera el daño base del disparo por algun multiplicador, para ello la propiedad damagetotal
		protected int DamageTotal { get; set; }
		protected int DamageBase => 10;

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