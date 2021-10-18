using Gestalt.Bullets;
using Godot;

namespace Gestalt.Life
{
	public class LifeBoss : LifeBase
	{
		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		private float firsThirdHealt;
		private float secondThirdHealt;
		private float LastThirdHealt;
		[Export] private PackedScene lifeBar;
		[Signal]
		public delegate void FirstThird();
		[Signal]
		public delegate void SecondThird();
		[Signal]
		public delegate void LastThird();
		
		public override void _Ready()
		{
			base._Ready();
			barCanvas = (CanvasLayer)lifeBar.Instance();
			barLife = barCanvas.GetChild<TextureProgress>(0);
			SetBarLife(Health, MaxHealth);
			Entity.CallDeferred("add_child", barCanvas);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
		}
		
		private void SetBarLife(float currentLife)
		{
			barLife.Value = currentLife;
		}

		private void SetBarLife(float currentLife, float maxLife)
		{
			barLife.MaxValue = maxLife;
			barLife.Value = currentLife;
		}

		protected override void GetDamage(float damage)
		{
			Health -= damage;
			SetBarLife(Health);
		}

		public override void ShootEnter(Area2D bullet)
		{
			if (!bullet.GetGroups().Contains("shootPlayer")) return;
			var bulletPlayer = (BulletBase)bullet;
			GetDamage(bulletPlayer.Damage);
		}
	}
}