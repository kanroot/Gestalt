using System.Collections.Generic;
using Godot;
using Laugh.Bullets;

namespace Laugh.TypeOfShoots
{
	public abstract class ShootBase
	{
		protected PackedScene Bullet;
		protected int CountSpawn;
		protected KinematicBody2D Entity;
		protected PackedScene Spawn;
		protected float SpeedBullet;

		protected ShootBase(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
			KinematicBody2D entity)
		{
			Spawn = spawn;
			CountSpawn = countSpawn;
			Bullet = bullet;
			SpeedBullet = speedBullet;
			Entity = entity;
		}

		public bool CanRotate { get; set; }

		public abstract void CreateSpawn();
		public abstract List<BasicBulletEnemy> CreateBullet();
		public abstract void KillNodes();

		public abstract void Rotate();
	}
}