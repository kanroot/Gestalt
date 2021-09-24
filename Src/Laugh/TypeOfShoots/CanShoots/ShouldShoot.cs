using Godot;

namespace Laugh.Shoots.CanShoots
{
	public abstract class ShouldShoot : Node
	{
		protected KinematicBody2D Entity;
		protected Position2D BulletOrigin;
		protected PackedScene BulletScene;
		public float SpeedBullet { get; set; }
		protected Timer TimerCanShoot;
		protected NodePath TimerPath;
		protected float TimeWait = 0.5f;
		public bool ThisCanShoot { get; set; }

		// protected ShouldShoot(bool thisCanShoot, KinematicBody2D entity, PackedScene bulletScene)
		// {
		// 	ThisCanShoot = thisCanShoot;
		// 	Entity = entity;
		// 	BulletScene = bulletScene;
		// }

		public override void _Ready()
		{
			Entity.Connect("ready", this, nameof(AddNodeSpawnBullet));
		}

		//cada cual vera como instanciar sus balas
		protected abstract void CreateBullet();

		public abstract void AddNodeSpawnBullet();

		public abstract void KillNodes();
	}
}