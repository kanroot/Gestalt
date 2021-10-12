using System;
using System.Collections.Generic;
using System.Linq;
using Gestalt.Bullets;
using Godot;

namespace Gestalt.Shoots
{
	public class ShootCircleEnemy : ShootBase

	{
		private readonly float angle;
		private readonly int degreesRotate;
		private readonly int directionToRotation;
		private BasicBulletEnemy basicBulletInstance;
		private Node2D spawmNode;
		private List<Node2D> spawnList;
		private float sumAngle;


		public ShootCircleEnemy(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
			KinematicBody2D entity, int directionToRotation, int degreesRotate) : base(spawn,
			countSpawn, bullet, speedBullet, entity)
		{
			angle = (float)360 / CountSpawn;
			sumAngle = angle;
			this.directionToRotation = directionToRotation;
			this.degreesRotate = degreesRotate;
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

		public override List<BasicBulletEnemy> CreateBullet()
		{
			return spawnList.Select(CreateInstanceBullet).ToList();
		}

		private BasicBulletEnemy CreateInstanceBullet(Node2D originNode2d)
		{
			basicBulletInstance = (BasicBulletEnemy)Bullet.Instance();
			basicBulletInstance.SpeedBullet = SpeedBullet;
			var position2d = originNode2d.GetChild<Position2D>(0);
			basicBulletInstance.Position = position2d.GlobalPosition;
			basicBulletInstance.RotationDegrees = originNode2d.RotationDegrees;
			return basicBulletInstance;
		}

		public override void KillNodes()
		{
			foreach (Node n in Entity.GetChildren())
				if (n.GetChildCount() > 0 && n.GetChild<Node>(0) is Position2D)
					n.QueueFree();
		}

		public override void Rotate()
		{
			if (CanRotate == false) return;
			foreach (var originNode2d in spawnList)
			{
				var degreesToRadiant = Math.PI / 180 * degreesRotate;
				originNode2d.Rotate((float)degreesToRadiant * directionToRotation);
			}
		}
	}
}