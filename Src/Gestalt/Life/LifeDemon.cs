using Gestalt.Bullets;
using Godot;

namespace Gestalt.Life
{
	public class LifeDemon : LifeBoss
	{
		[Signal]
		public delegate void DeathBoss();

		[Signal]
		public delegate void FirstThird();

		[Signal]
		public delegate void SecondThird();
		private float firsThirdHealth;
		private float secondThirdHealth;

		public override void _Ready()
		{
			base._Ready();
			CalLife();
		}

		public override void ShootEnter(Area2D bullet)
		{
			if (!bullet.GetGroups().Contains("shootPlayer")) return;
			var bulletPlayer = (BulletBase)bullet;
			GetDamage(bulletPlayer.Damage);
			Switcher();
		}

		private void Switcher()
		{
			if (Health < secondThirdHealth && Health > firsThirdHealth)
			{
				EmitSignal(nameof(SecondThird));
			}
			else
			{
				if (Health < firsThirdHealth && Health > 0)
				{
					EmitSignal(nameof(FirstThird));
				}
				else
				{
					if (!(Health <= 0)) return;
					EmitSignal(nameof(DeathBoss));
				}
			}
		}

		private void CalLife()
		{
			firsThirdHealth = MaxHealth / 3;
			secondThirdHealth = firsThirdHealth * 2;
		}
	}
}