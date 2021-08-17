using Godot;

namespace Laugh.Shoots
{
	public class CanShootPj : CanShootBase
	{
		private Node2D rotate;
		[Export] private NodePath rotatePath;
		private bool mouserOverPlayer;
		[Export] private NodePath bulletPath;

		public override void _Ready()
		{
			base._Ready();
			//propias
			rotate = GetNode<Node2D>(rotatePath);
			TimerCanShoot.Connect("timeout", this, nameof(OnEndTime));
			Entity.Connect("mouse_entered", this, nameof(OnMousePlayer));
			Entity.Connect("mouse_exited", this, nameof(OnMousePlayerExit));
			BulletOrigin = GetNode<Position2D>(bulletPath);
		}

		public override void _Process(float delta)
		{
			Aim();
		}

		private void Aim()
		{
			rotate.LookAt(rotate.GetGlobalMousePosition());
			GetInputFire();
		}
		
		protected override void CreateBullet()
		{
			if (!Canfire) return;
			var bulletInstance = (Shoot)BulletScene.Instance();
			bulletInstance.Position = BulletOrigin.GlobalPosition;
			GetTree().Root.AddChild(bulletInstance);
			Canfire = false;
			TimerCanShoot.Start();
		}
		private void OnMousePlayer()
		{
			mouserOverPlayer = true;
		}

		private void OnMousePlayerExit()
		{
			mouserOverPlayer = false;
			Canfire = true;
		}

		private void GetInputFire()
		{
			if (!Input.IsActionPressed("Fire") || mouserOverPlayer) return;
			CreateBullet();
		}

		protected void OnEndTime()
		{
			if (mouserOverPlayer) return;
			Canfire = true;
		}
	}
}