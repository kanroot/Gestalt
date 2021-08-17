using Godot;

namespace Laugh.Shoots
{
	public class CanShootPlayer : CanShootBase
	{
		private bool mouserOverPlayer;

		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("mouse_entered", this, nameof(OnMousePlayer));
			Entity.Connect("mouse_exited", this, nameof(OnMousePlayerExit));
		}

		protected override void Aim()
		{
			rotate.LookAt(rotate.GetGlobalMousePosition());
			GetInputFire();
		}

		private void OnMousePlayer()
		{
			mouserOverPlayer = true;
		}

		private void OnMousePlayerExit()
		{
			mouserOverPlayer = false;
			Canfire = true;
		}

		private void GetInputFire()
		{
			if (!Input.IsActionPressed("Fire") || mouserOverPlayer) return;
			CreateBullet();
		}

		protected override void OnEndTime()
		{
			if (mouserOverPlayer) return;
			base.OnEndTime();
		}
	}
}