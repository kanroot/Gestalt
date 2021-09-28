using Godot;
using Laugh.TypeOfShoots;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Enemy
{
	[RegisteredType(nameof(Movement), "res://logos//rei.png", nameof(Node))]
	public class Shoot : Node
	{
		[Export] private PackedScene bulletScene;
		[Export] private int countSpawn;
		[Export] private int degreesToRotate;
		[Export] private int directionToRotation;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private ShootBase shootBase;
		[Export] private PackedScene spawnNode;
		[Export] private float speedBullet;
		[Export] private NodePath timerPath;
		private Timer timeToShoot;
		[Export] public bool CanShoot { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			shootBase = new ShootCircleEnemy(spawnNode, countSpawn, bulletScene, speedBullet, entity,
				directionToRotation, degreesToRotate);
			shootBase.CreateSpawn();
			timeToShoot = GetNode<Timer>(timerPath);
			timeToShoot.Connect("timeout", this, nameof(SetCanShoot));
			shootBase.CanRotate = true;
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