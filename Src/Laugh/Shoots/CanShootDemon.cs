using System;
using Godot;

namespace Laugh.Shoots
{
	public class CanShootDemon : CanShootEnemy
	{
		private const float Circle = 360;
		private ShootDemon bulletInstance;
		[Export] public int CountDivisionCircle { get; set; }
		[Export] public int DegreesRotate { get; set; }
		[Export] public float SpeedBullet { get; set; }
		public bool CanRotateNode { get; set; }

		public override void _Ready()
		{
			base._Ready();
			CanRotateNode = true;
		}

		public override void _PhysicsProcess(float delta)
		{
			RotaryNode2D();
		}

		public override void CallerPosition()
		{
			CreatePosition();
			ModifyPosition2d();
		}

		private void CreatePosition()
		{
			for (var i = 0; i < CountDivisionCircle; i++)
			{
				var position2d = (Node2D)RotatePosition2d.Instance();
				ListPosition2d.Add(position2d);
				Entity.AddChild(position2d);
				position2d.LookAt(Vector2.Up);
			}
		}

		private void ModifyPosition2d()
		{
			var angle = Circle / CountDivisionCircle;
			for (var i = 1; i != CountDivisionCircle; i++) ListPosition2d[i].RotationDegrees += angle * i;
		}

		protected override void CreateBullet()
		{
			if (Canfire != true) return;
			foreach (var originNode2d in ListPosition2d) BulletInstance(originNode2d);
		}

		private void BulletInstance(Node2D originNode2d)
		{
			bulletInstance = (ShootDemon)BulletScene.Instance();
			bulletInstance.SpeedBullet = SpeedBullet;
			var position2d = originNode2d.GetChild<Position2D>(0);
			bulletInstance.Position = position2d.GlobalPosition;
			bulletInstance.RotationDegrees = originNode2d.RotationDegrees;
			GetTree().Root.AddChild(bulletInstance);
		}

		private void RotaryNode2D()
		{
			if (CanRotateNode != true) return;
			foreach (var originNode2d in ListPosition2d)
			{
				var degreesToRadiant = Math.PI / 180 * DegreesRotate;
				originNode2d.Rotate((float)degreesToRadiant);
			}
		}

		public void KillNodes()
		{
			foreach (Node n in Entity.GetChildren())
				try
				{
					if (n.GetChild<Position2D>(0) != null) n.QueueFree();
				}
				catch (InvalidCastException e)
				{
					//do nothing xd
				}
		}
	}
}