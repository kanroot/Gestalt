using System;
using Gestalt.Bullets;
using Godot;

namespace Gestalt.Life
{
	public class LifeBoss : LifeBase
	{
		[Signal]
		public delegate void FirstThird();

		[Signal]
		public delegate void LastThird();

		[Signal]
		public delegate void SecondThird();
		
		[Signal]
		public delegate void DeathBoss();

		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		private float firsThirdHealt;
		[Export] private PackedScene lifeBar;
		private float secondThirdHealt;

		public override void _Ready()
		{
			base._Ready();
			barCanvas = (CanvasLayer)lifeBar.Instance();
			barLife = barCanvas.GetChild<TextureProgress>(0);
			SetBarLife(Health, MaxHealth);
			Entity.CallDeferred("add_child", barCanvas);
			CalLife();
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
			var bulletPlayer = (BulletBase) bullet;
			GetDamage(bulletPlayer.Damage);
			Switcher();
		}


		private void Switcher()
		{
			if (Health > secondThirdHealt && Health < MaxHealth)
			{
				EmitSignal(nameof(SecondThird));
			}
			else
			{
				if (Health < secondThirdHealt && Health > 0)
				{
					EmitSignal(nameof(FirstThird));
				}
				else
				{
					EmitSignal(nameof(DeathBoss));
				}
			}
		}


		private void CalLife()
		{
			firsThirdHealt = MaxHealth / 3;
			secondThirdHealt = firsThirdHealt * 2;
		}
	}
}