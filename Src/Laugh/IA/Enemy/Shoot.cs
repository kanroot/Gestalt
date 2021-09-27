using Godot;
using Laugh.TypeOfShoots;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Enemy
{
	[RegisteredType(nameof(Movement), "res://logos//rei.png", nameof(Node))]
	public class Shoot : Node
	{
		[Export] public bool CanShoot { get; set; }
		[Export] private int countSpawn;
		[Export] private float speedBullet;
		[Export] private int degreesToRotate;
		[Export] private int directionToRotation;
		[Export] private NodePath entityPath;
		[Export] private NodePath timerPath;
		[Export] private PackedScene bulletScene;
		private KinematicBody2D entity;
		private ShootBase shootBase;
		[Export] private PackedScene spawnNode;
		private Timer timeToShoot;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			shootBase = new ShootCircleEnemy(spawnNode, countSpawn, bulletScene, speedBullet, entity,
				directionToRotation, degreesToRotate);
			shootBase.CreateSpawn();
			timeToShoot = GetNode<Timer>(timerPath);
			timeToShoot.Connect("timeout", this, nameof(SetCanShoot));
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			shootBase.Rotate();
			CreateInstanceOfBullets();
		}

		public void SetShootBase(ShootBase shoot)
		{
			shootBase = shoot;
		}

		private void CreateInstanceOfBullets()
		{
			if (CanShoot == false) return;
			var listBullet = shootBase.CreateBullet();
			foreach (var n in listBullet) GetTree().Root.AddChild(n);
			CanShoot = false;
		}

		private void SetCanShoot()
		{
			CanShoot = true;
		}
	}
}