using GDMechanic.Wiring.Attributes;
using Godot;

namespace Laugh.Shoots
{
	public class ShootCircle : Area2D
	{
		//tiempo de vida
		[Child] private readonly Timer bulletFree = new Timer();
		[Export] private int damageBase = 10;
		[Export] private int lifetime = 1;

		private Vector2 mousePosition;

		//propia
		//spawn
		private Vector2 movement;
		[Export] private int speed = 15;

		//daño, el daño sera el daño base del disparo por algun multiplicador, para ello la propiedad damagetotal
		[Export] public int damageTotal { get; set; }


		public override void _Ready()
		{
			GetTree().Root.AddChild(bulletFree);
			bulletFree.Start(lifetime);
			//propia
			mousePosition = GetLocalMousePosition();
		}


		public override void _PhysicsProcess(float delta)
		{
			movement = movement.MoveToward(mousePosition, delta);
			movement = movement.Normalized() * speed;
			Position += movement;
		}

		//cuando entra en un cuerpo desaparece la instancia de bullet
		private void _on_ShootCircle_body_entered(Area2D area2D)
		{
			QueueFree();
		}

		private void _on_BulletFree_timeout()
		{
			QueueFree();
		}
	}
}