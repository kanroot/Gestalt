using System;
using System.Collections.Generic;
using Godot;
using Laugh.IA.FSM.Demon;

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

		public int DirectionToRotation { get; set; }

		public override void _Ready()
		{
			base._Ready();
			CanRotateNode = true;
			DirectionToRotation = 1;
		}

		public override void _PhysicsProcess(float delta)
		{
			RotaryNode2D();
		}

		public override void AddNodeSpawnBullet()
		{
			CreatePosition();
			ModifyPosition2d();
			Canfire = true;
		}

		private void CreatePosition()
		{
			ListPosition2d = new List<Node2D>();
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
				originNode2d.Rotate((float)degreesToRadiant * DirectionToRotation);
			}
		}
		
		public void KillNodes()
		{
			Canfire = false;
			foreach (Node n in Entity.GetChildren())
			{
				if (n.GetChildCount() <= 0) continue;
				if (n.GetChild<Node>(0) is Position2D)
				{
					n.QueueFree();
				}
			}
		}
	}
}