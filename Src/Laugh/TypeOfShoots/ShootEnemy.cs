using System.Collections.Generic;
using Godot;

namespace Laugh.TypeOfShoots
{
	public class ShootEnemy : ShootBase

	{
		private List<Node2D> spawnList;
		private Node2D spawmNode;
		private float angle;
		private float sumAngle = 0;

		public ShootEnemy(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
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
				ModifyPosition2d(spawmNode);
				spawnList.Add(spawmNode);
				Entity.CallDeferred("add_child", spawmNode);
			}
		}
		
		
		public void ModifyPosition2d(Node2D spawn)
		{
			var position2D = spawn.GetChild<Position2D>(0);
			position2D.RotationDegrees = sumAngle;
			sumAngle += angle;
		}
		

		public override void CreateBullet()
		{
			throw new System.NotImplementedException();
		}

		public override void KillNodes()
		{
			throw new System.NotImplementedException();
		}
	}
}