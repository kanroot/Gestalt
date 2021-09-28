using Godot;

namespace Laugh.Life
{
	public class LifeBoss : LifeBase
	{
		public override void ShootEnter(Area2D bullet)
		{
			if (!bullet.GetGroups().Contains("shootPlayer")) return;
			GetDamage(10);
		}
	}
}