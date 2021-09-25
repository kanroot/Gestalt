using System;
using System.Collections.Generic;
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
			angle = (float) 360 / CountSpawn;
			sumAngle = angle;
		}

		public override void CreateSpawn()
		{
			for (var i = 1; i <= CountSpawn; i++)
			{
				spawnList =  new List<Node2D>();
				spawmNode = (Node2D) Spawn.Instance();
				ModifyPosition2D(spawmNode);
				spawnList.Add(spawmNode);
				Entity.CallDeferred("add_child", spawmNode);
			}
		}

		private void ModifyPosition2D(Node2D spawn)
		{
			var position2D = spawn.GetChild<Position2D>(0);
			position2D.RotationDegrees = sumAngle;
			sumAngle += angle;
		}
		

		public override void CreateBullet()
		{
			foreach (var spawn in spawnList)
			{
				CreateInstanceBullet(spawn);
			}
		}
		
		private void CreateInstanceBullet(Node2D originNode2d)
		{
			bulletInstance = (ShootEnemy) Bullet.Instance();
			bulletInstance.SpeedBullet = SpeedBullet;
			var position2d = originNode2d.GetChild<Position2D>(0);
			bulletInstance.Position = position2d.GlobalPosition;
			bulletInstance.RotationDegrees = originNode2d.RotationDegrees;
			//GetTree().Root.AddChild(bulletInstance);
		}

		public override void KillNodes()
		{
			throw new System.NotImplementedException();
		}
	}
}