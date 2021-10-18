using Gestalt.Shoots;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.Nodes.EnemyNodes
{
	[RegisteredType(nameof(ShootNode))]
	public class ShootNode : Node
	{
		private ShootBase shootBase;
		[Export] public bool CanShoot { get; set; }

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
		}
	}
}