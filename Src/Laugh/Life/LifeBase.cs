using Godot;

namespace Laugh.Life
{
	public abstract class LifeBase : Node
	{
		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		[Export] private float maxhealth;
		[Export] private float health;
		[Export] private PackedScene lifeBar;
		[Export] private PackedScene packedSceneRadius;
		private Area2D area2DCollision;

		public override void _Ready()
		{
			barCanvas = (CanvasLayer)lifeBar.Instance();
			barLife = barCanvas.GetChild<TextureProgress>(0);
			SetBarLife(health, maxhealth);
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.CallDeferred("add_child", barCanvas);
			entity.Connect("ready", this, nameof(AddCollisionShape));
			entity.Connect("ready", this, nameof(AddConnect));
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

		private void AddCollisionShape()
		{
			area2DCollision = (Area2D)packedSceneRadius.Instance();
			var collisionShape = area2DCollision.GetChild<CollisionShape2D>(0);
			var entityShape = entity.GetChild<CollisionShape2D>(0);
			collisionShape.Scale = entityShape.Scale;
			collisionShape.Shape = entityShape.Shape;
			entity.AddChild(area2DCollision);
		}

		private void AddConnect()
		{
			area2DCollision.Connect("area_entered", this, nameof(ShootEnter));
		}

		protected void GetDamage(float damage)
		{
			health -= damage;
			SetBarLife(health);
		}

		public abstract void ShootEnter(Area2D bullet);
		
		//implementar como señal
		protected void Death()
		{
			if (health > 0) return;
			entity.QueueFree();
		}
	}
}