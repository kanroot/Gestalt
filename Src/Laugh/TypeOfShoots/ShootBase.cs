using System.Collections.Generic;
using Godot;
using Laugh.TypeOfShoots.ConductOfShoots;

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

		public abstract void CreateSpawn();
		public abstract List<ShootEnemy> CreateBullet();
		public abstract void KillNodes();

		public abstract void Rotate();
	}
}