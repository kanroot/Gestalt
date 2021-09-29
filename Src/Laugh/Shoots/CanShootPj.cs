using Godot;
using Laugh.Bullets;

namespace Laugh.Shoots
{
	public class CanShootPj : CanShootBase
	{
		[Export] private NodePath bulletPath;
		[Export] protected PackedScene BulletScene;
		private bool mouserOverPlayer;
		private Node2D rotate;
		[Export] private NodePath rotatePath;

		public override void _Ready()
		{
			base._Ready();
			Entity = GetParent<KinematicBody2D>();
			rotate = GetNode<Node2D>(rotatePath);
			TimerCanShoot.Connect("timeout", this, nameof(OnEndTime));
			Entity.Connect("mouse_entered", this, nameof(OnMousePlayer));
			Entity.Connect("mouse_exited", this, nameof(OnMousePlayerExit));
			BulletOrigin = GetNode<Position2D>(bulletPath);
			CanShoot = true;
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
			if (!CanShoot) return;
			var bulletInstance = (BulletBase)BulletScene.Instance();
			bulletInstance.Position = BulletOrigin.GlobalPosition;
			bulletInstance.SpeedBullet = SpeedBullet;
			bulletInstance.AddToGroup("bullet");
			GetTree().Root.AddChild(bulletInstance);
			CanShoot = false;
			TimerCanShoot.Start();
		}

		private void OnMousePlayer()
		{
			mouserOverPlayer = true;
		}

		private void OnMousePlayerExit()
		{
			mouserOverPlayer = false;
			CanShoot = true;
		}

		private void GetInputFire()
		{
			if (!Input.IsActionPressed("Fire") || mouserOverPlayer) return;
			CreateBullet();
		}

		protected void OnEndTime()
		{
			if (mouserOverPlayer) return;
			CanShoot = true;
		}
	}
}