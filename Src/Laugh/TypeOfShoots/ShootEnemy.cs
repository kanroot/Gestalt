using System.Collections.Generic;
using Godot;

namespace Laugh.TypeOfShoots
{
	public class ShootEnemy : ShootBase

	{
		private List<Node2D> spawnList;
		private Node2D spawmNode;

		public ShootEnemy(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
			KinematicBody2D entity) : base(spawn, countSpawn, bullet, speedBullet, entity)
		{
		}

		public override void CreateSpawn()
		{
			for (var i = 1; i <= CountSpawn; i++)
			{
				spawnList =  new List<Node2D>();
				spawmNode = (Node2D) Spawn.Instance();
				spawnList.Add(spawmNode);
				Entity.CallDeferred("add_child", spawmNode);
			}
			
		}
		
		public void ModifyPosition2d()
		{
			var angle = 360 / CountSpawn;
			foreach (var n in spawnList)
			{
				GD.Print(angle.ToString());
				angle += angle;
			}
			//for (var i = 1; i != CountSpawn; i++) spawnList[i].RotationDegrees += angle * i;
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