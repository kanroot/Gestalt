using Gestalt.Shoots;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.IA.Enemy
{
	[RegisteredType(nameof(ShootNode),nameof(Node))]
	public class ShootNode : Node
	{
		
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private ShootBase shootBase;
		[Export] public bool CanShoot { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			if (CanShoot == false) return;
			shootBase.Rotate();
			CreateInstanceOfBullets();
		}

		public void SetShootBase(ShootBase shoot)
		{
			shootBase = shoot;
		}

		private void CreateInstanceOfBullets()
		{
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