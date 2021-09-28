using Godot;

namespace Laugh.Life
{
	public class LifeBase : Node
	{
		private CanvasLayer barCanvas;
		private KinematicBody2D entity;
		[Export] protected NodePath entityPath;
		[Export] protected float health;
		[Export] public PackedScene lifeBar;

		public override void _Ready()
		{
			barCanvas = (CanvasLayer)lifeBar.Instance();
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.CallDeferred("add_child", barCanvas);
		}


		public void GetDamage(float damage)
		{
			health -= damage;
		}


		//implementar como señal
		protected void Death()
		{
			if (health > 0) return;
			entity.QueueFree();
		}

		//implementar como señal
		protected void GrowingLife(int value)
		{
			health += value;
		}
	}
}