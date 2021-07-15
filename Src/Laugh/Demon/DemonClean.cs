using System;
using Godot;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Laugh.BaseClass;
using Laugh.Player;
using Laugh.Shoots;

namespace Laugh.Demon
{
	public class DemonClean : BaseKinematic
	{
		
		private readonly PackedScene shootDemon =
			ResourceLoader.Load<PackedScene>("res://Src//Prefabs//ShootEnemy.tscn");
		public override void _Ready()
		{
			DirectionKinematic = new Vector2(0, 0);
			Speed = 500;
			FireDelay.OneShot = false;
			FireDelay.WaitTime = FireDelayTime;
			this.Wire();
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			Node2D.Rotate((float) 0.01);
			ShootBullet();
		}

		private void ShootBullet()
		{
			if (CanFire == false) return;
			var bulletInstance = (ShootDemon) shootDemon.Instance();
			if (bulletInstance == null) return;
			bulletInstance.Position = PositionShoot.GlobalPosition;
			GetTree().Root.AddChild(bulletInstance);
			CanFire = false;
			FireDelay.Start();
		}

		public override void _PhysicsProcess(float delta)
		{
			//actualiza la direccion entanto rebota
			DirecctionDemonBounce(delta);
			MoveAndSlide(DirectionKinematic);
		}

		private void DirecctionDemonBounce(float delta)
		{
			//muevo al personaje segun colisione, la nueva direccion sera entanto la direccion de rebote
			var collision = MoveAndCollide(DirectionKinematic * Speed * delta);
			if (collision != null)
			{
				DirectionKinematic = DirectionKinematic.Bounce(collision.Normal);
			}
		}
	}
}