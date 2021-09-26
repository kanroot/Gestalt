using Godot;
using Laugh.TypeOfShoots;
using MonoCustomResourceRegistry;

namespace Laugh.IA.Enemy
{
	[RegisteredType(nameof(Movement), "res://logos//rei.png", nameof(Node))]
	public class Shoot : Node
	{
		private KinematicBody2D entity;
		[Export()] private NodePath entityPath;
		[Export()] private int countSpawn;
		[Export()] private float speedBullet;
		[Export()] private PackedScene spawnNode;
		[Export()] private PackedScene bulletScene;
		private ShootBase shootBase;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			shootBase = new ShootCircleEnemy(spawnNode, countSpawn, bulletScene, speedBullet, entity);
			shootBase.CreateSpawn();
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			var listInstanceShoot = shootBase.CreateBullet();
			foreach (var n in listInstanceShoot) GetTree().Root.AddChild(n);
		}
	}
}