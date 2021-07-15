using GDMechanic.Wiring;
using Godot;
using GDMechanic.Wiring.Attributes;
using Laugh.BaseClass;
using Laugh.Shoots;

namespace Laugh.Player
{
	public class PlayerClean : BaseKinematic
	{
		//propias
		[Export] private float SpeedRotateLine { get; set; } = (float) (-0.008 / 0.5);
		[Child] private AnimatedSprite LineOutside { get; set; } = new AnimatedSprite();

		public override void _Ready()
		{
			//preguntar por los timers y como obtener el nodo en especifico
			FireDelay.OneShot = false;
			FireDelay.WaitTime = 1;
			this.Wire();
		}
		
		public override void _Process(float delta)
		{
			TextAnimated.Rotate(SpeedRotateText);
			LineOutside.Rotate(SpeedRotateLine);
			//usado para que position2d gire entorno a la posicion del mouse
			Node2D.LookAt(GetGlobalMousePosition());
			GetInputFire();
		}
		
		private void GetInputFire()
		{
			if (!Input.IsActionPressed("Fire") || CanFire == false) return;
			ShootBullet();
		}

		private void ShootBullet()
		{
			var bulletInstance = (ShootPlayer) ShootCircle.Instance();
			if (bulletInstance == null) return;
			var position2D = (Position2D) Node2D.GetChild(0);
			bulletInstance.Position = PositionShoot.GlobalPosition;
			GetTree().Root.AddChild(bulletInstance);
			CanFire = false;
			FireDelay.Start();
		}
		
		public override void _PhysicsProcess(float delta)
		{
			MoveAndSlide(GetInputMovement());
		}

		private Vector2 GetInputMovement()
		{
			var directionPlayerVector = new Vector2();

			if (Input.IsActionPressed("ui_right"))
				directionPlayerVector.x += 1;

			if (Input.IsActionPressed("ui_left"))
				directionPlayerVector.x -= 1;

			if (Input.IsActionPressed("ui_down"))
				directionPlayerVector.y = 1;

			if (Input.IsActionPressed("ui_up"))
				directionPlayerVector.y -= 1;

			return directionPlayerVector * Speed;
		}
		
		private void _on_Player_mouse_entered()
		{
			CanFire = false;
		}

		private void _on_Player_mouse_exited()
		{
			CanFire = true;
		}

		
	}
}