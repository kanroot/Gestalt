using System.Collections.Generic;
using Godot;
using Laugh.IA.Enemy;
using Laugh.Shoots.ConductOfShoots;

namespace Laugh.TypeOfShoots
{
	public abstract class ShootBase
	{
		protected PackedScene Spawn;
		protected int CountSpawn;
		protected PackedScene Bullet;
		protected float SpeedBullet;
		protected KinematicBody2D Entity;
		public bool CanShoot { get; set; }

		protected ShootBase(PackedScene spawn, int countSpawn, PackedScene bullet, float speedBullet,
			KinematicBody2D entity)
		{
			Spawn = spawn;
			CountSpawn = countSpawn;
			Bullet = bullet;
			SpeedBullet = speedBullet;
			Entity = entity;
			CanShoot = false;
		}

		public abstract void CreateSpawn();
		public abstract List<ShootEnemy> CreateBullet();
		public abstract void KillNodes();
	}
}