using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots.CanShoots
{
	public class Enemy : ShouldShoot
	{
		[Export] protected PackedScene BulletSpawn;
		protected List<Node2D> ListPosition2d;

		// public Enemy(PackedScene bulletSpawn, bool thisCanShoot, KinematicBody2D entity,
		// 	PackedScene bulletScene) : base(thisCanShoot, entity, bulletScene)
		// {
		// 	BulletSpawn = bulletScene;
		// }

		public override void _Ready()
		{
			base._Ready();
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
		}

		protected override void CreateBullet()
		{
			throw new System.NotImplementedException();
		}

		public override void AddNodeSpawnBullet()
		{
			throw new System.NotImplementedException();
		}

		public override void KillNodes()
		{
			throw new System.NotImplementedException();
		}
	}
}