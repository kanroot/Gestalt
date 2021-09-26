using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Laugh.Shoots.ConductOfShoots;
using Shoot = Laugh.IA.Enemy.Shoot;

namespace Laugh.TypeOfShoots
{
	public class ShootCircleEnemy : ShootBase

	{
		private List<Node2D> spawnList;
		private Node2D spawmNode;
		private float angle;
		private float sumAngle = 0;

		private ShootEnemy bulletInstance;

		public ShootCircleEnemy(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
			KinematicBody2D entity) : base(spawn, countSpawn, bullet, speedBullet, entity)
		{
			angle = (float)360 / CountSpawn;
			sumAngle = angle;
		}

		public override void CreateSpawn()
		{
			spawnList = new List<Node2D>();
			for (var i = 1; i <= CountSpawn; i++)
			{
				spawmNode = (Node2D)Spawn.Instance();
				ModifyPosition2D(spawmNode);
				spawnList.Add(spawmNode);
				Entity.CallDeferred("add_child", spawmNode);
			}
		}

		private void ModifyPosition2D(Node2D spawn)
		{
			spawn.RotationDegrees = sumAngle;
			sumAngle += angle;
		}


		public override List<ShootEnemy> CreateBullet()
		{
			return spawnList.Select(CreateInstanceBullet).ToList();
		}

		private ShootEnemy CreateInstanceBullet(Node2D originNode2d)
		{
			bulletInstance = (ShootEnemy)Bullet.Instance();
			bulletInstance.SpeedBullet = SpeedBullet;
			var position2d = originNode2d.GetChild<Position2D>(0);
			bulletInstance.Position = position2d.GlobalPosition;
			bulletInstance.RotationDegrees = originNode2d.RotationDegrees;
			return bulletInstance;
		}

		public override void KillNodes()
		{
			CanShoot = false;
			foreach (Node n in Entity.GetChildren())
				if (n.GetChildCount() > 0 && n.GetChild<Node>(0) is Position2D)
					n.QueueFree();
		}
	}
}