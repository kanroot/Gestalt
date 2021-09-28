using Godot;

namespace Laugh.Life
{
	public class LifeBase : Node
	{
		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		[Export] private float health;
		[Export] private PackedScene lifeBar;
		[Export] private PackedScene packedSceneRadius;
		private Area2D area2DCollision;

		public override void _Ready()
		{
			barCanvas = (CanvasLayer)lifeBar.Instance();
			SetBar(health);
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.CallDeferred("add_child", barCanvas);
			entity.Connect("ready", this, nameof(AddCollisionShape));
			entity.Connect("ready", this, nameof(AddConnect));
		}

		private void SetBar(float life)
		{
			barLife = barCanvas.GetChild<TextureProgress>(0);
			barLife.Value = life;
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

		private void GetDamage(float damage)
		{
			health -= damage;
			SetBar(health);
		}

		public void ShootEnter(Area2D bullet)
		{
			if (!bullet.GetGroups().Contains("shootPlayer")) return;
			GetDamage(10);
			GD.Print("entre");
		}
		
		//implementar como señal
		protected void Death()
		{
			if (health > 0) return;
			entity.QueueFree();
		}
	}
}