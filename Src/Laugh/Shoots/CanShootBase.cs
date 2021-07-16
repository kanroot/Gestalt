using Godot;

namespace Laugh.Shoots
{
	public abstract class CanShootBase : Node
	{
		protected KinematicBody2D entity;
		[Export] private PackedScene bulletScene;
		[Export] private NodePath timerPath;
		[Export] private NodePath bulletPath;
		[Export] private NodePath rotatePath;
		private Timer timerCanShoot;
		private Position2D bulletOrigin;
		protected Node2D rotate;
		[Export] protected bool Canfire = true;
		[Export] private float timeWait = 0.5f;
		
		public override void _Ready()
		{
			entity = GetParent<KinematicBody2D>();
			bulletOrigin = GetNode<Position2D>(bulletPath);
			timerCanShoot = GetNode<Timer>(timerPath);
			rotate = GetNode<Node2D>(rotatePath);
			timerCanShoot.Connect("timeout",this, nameof(OnEndTime));
			timerCanShoot.WaitTime = timeWait;
		}

		public override void _Process(float delta)
		{
			Aim();
		}

		protected void CreateBullet()
		{
			if (!Canfire) return;
			var bulletInstance = (Shoot) bulletScene.Instance();
			bulletInstance.Position = bulletOrigin.GlobalPosition;
			GetTree().Root.AddChild(bulletInstance);
			Canfire = false;
			timerCanShoot.Start();
		}

		protected abstract void Aim();
		
		protected virtual void OnEndTime()
		{
			Canfire = true;
		}

	}
}