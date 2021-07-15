using System;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace Laugh.Demon
{
	public class Demon : KinematicBody2D
	{
		//cuerpo y giro
		[Child] private AnimatedSprite TextAnimated;
		[Export] private float speedRotateText = (float) -0.008;

		//movimiento
		private Vector2 directionDemon = new Vector2(1, 0);
		[Export] private int speed = 500;

		//disparo
		[Child] private Node2D node2D;
		[Export] private int speedRotation = 100;
		[Export] private float fireDelayTime = (float) .25;

		public override void _Ready()
		{
			this.Wire();
		}


		public override void _Process(float delta)
		{
			TextAnimated.Rotate(speedRotateText);
		}

		public override void _PhysicsProcess(float delta)
		{
			//actualiza la direccion entanto rebota
			DirecctionDemonBounce(delta);
			MoveAndSlide(directionDemon);
		}

		private void DirecctionDemonBounce(float delta)
		{
			//muevo al personaje segun colisione, la nueva direccion sera entanto la direccion de rebote
			var collision = MoveAndCollide(directionDemon * speed * delta);
			if (collision != null)
			{
				directionDemon = directionDemon.Bounce(collision.Normal);
			}
		}
	}
}