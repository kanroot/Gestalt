using GDMechanic.Wiring.Attributes;
using Godot;

namespace Laugh.Shoots
{
	public class Shoot : Area2D
	{
		protected Timer BulletFree { get; set; } = new Timer();
		protected int Lifetime { get; set; }
		protected int Speed { get; set; }

		//daño, el daño sera el daño base del disparo por algun multiplicador, para ello la propiedad damagetotal
		protected int DamageTotal { get; set; }

		protected int DamageBase
		{
			get => 10;
		}

		//cuando entra en un cuerpo desaparece la instancia de bullet
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