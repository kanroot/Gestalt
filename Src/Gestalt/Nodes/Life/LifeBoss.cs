using Godot;

namespace Gestalt.Life
{
	public class LifeBoss : LifeBase
	{
		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		[Export] private PackedScene lifeBar;
		[Export] private string nameBoss;
		private VBoxContainer vBoxContainer;

		public override void _Ready()
		{
			base._Ready();
			barCanvas = (CanvasLayer)lifeBar.Instance();
			GetChild();
			SetBarLife(Health, MaxHealth);
			Entity.CallDeferred("add_child", barCanvas);
		}

		private void GetChild()
		{
			vBoxContainer = barCanvas.GetChild<VBoxContainer>(0);
			barLife = vBoxContainer.GetChild<TextureProgress>(0);
			var text = vBoxContainer.GetChild<Label>(1);
			text.Text = nameBoss;
			text.Align = Label.AlignEnum.Center;
			vBoxContainer.Alignment = BoxContainer.AlignMode.Center;
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
			//No puede utilizar el base._ready()
		}
	}
}