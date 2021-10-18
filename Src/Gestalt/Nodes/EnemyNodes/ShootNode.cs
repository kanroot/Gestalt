using Gestalt.Shoots;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.Nodes.EnemyNodes
{
	[RegisteredType(nameof(ShootNode))]
	public class ShootNode : Node
	{
		public Timer TimerToShoot;
		private ShootBase shootBase;
		[Export] public bool CanShoot { get; set; }
		[Export()] private NodePath timerPath;

		public override void _Ready()
		{
			TimerToShoot = GetNode<Timer>(timerPath);
			TimerToShoot.Connect("timeout", this, nameof(TriggerShoot));
		}

		private void TriggerShoot()
		{
			CanShoot = true;
		}

		public override void _Process(float delta)
		
		{
			if (CanShoot == false) return;
			shootBase.Rotate();
			CreateInstanceOfBullets();
		}

		public void SetPattern(ShootBase shoot)
		{
			shootBase = shoot;
		}

		private void CreateInstanceOfBullets()
		{
			var listBullet = shootBase.CreateBullet();
			foreach (var n in listBullet) GetTree().Root.AddChild(n);
			CanShoot = false;
		}
	}
}