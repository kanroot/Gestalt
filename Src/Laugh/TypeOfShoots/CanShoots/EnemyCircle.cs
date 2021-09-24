using System;
using System.Collections.Generic;
using Godot;
using Laugh.Shoots.ConductOfShoots;

namespace Laugh.Shoots.CanShoots
{
	public class EnemyCircle : Enemy
	{
		private const float Circle = 360;
		private ShootEnemy bulletInstance;
		public int CountDivisionCircle { get; set; }
		public int DegreesRotate { get; set; }
		public bool CanRotateNode { get; set; }
		public int DirectionToRotation { get; set; }

		private PackedScene bulletSpawn;
		private bool thisCanShoot;
		private KinematicBody2D entity;
		private PackedScene bulletScene;


		public void CreateEnemy(PackedScene bulletSpawn, bool thisCanShoot, KinematicBody2D entity,
			PackedScene bulletScene)
		{
			this.bulletSpawn = bulletSpawn;
			this.thisCanShoot = thisCanShoot;
			this.entity = entity;
		}

		// public EnemyCircle(PackedScene bulletSpawn, bool thisCanShoot, KinematicBody2D entity,
		// 	PackedScene bulletScene) : base(bulletSpawn, thisCanShoot, entity,
		// 	bulletScene)
		// {
		// 	
		// }

		public override void AddNodeSpawnBullet()
		{
			CreatePosition();
			ModifyPosition2d();
		}

		private void CreatePosition()
		{
			ListPosition2d = new List<Node2D>();
			for (var i = 0; i < CountDivisionCircle; i++)
			{
				var position2d = (Node2D)BulletSpawn.Instance();
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
			if (ThisCanShoot != true) return;
			foreach (var originNode2d in ListPosition2d) BulletInstance(originNode2d);
		}

		private void BulletInstance(Node2D originNode2d)
		{
			bulletInstance = (ShootEnemy)BulletScene.Instance();
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

		public override void KillNodes()
		{
			ThisCanShoot = false;
			foreach (Node n in Entity.GetChildren())
				if (n.GetChildCount() > 0 && n.GetChild<Node>(0) is Position2D)
					n.QueueFree();
		}
	}
}