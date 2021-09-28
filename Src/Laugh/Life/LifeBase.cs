using Godot;

namespace Laugh.Life
{
	public class LifeBase : Node
	{
		private CanvasLayer barCanvas;
		private TextureProgress barLife;
		private KinematicBody2D entity;
		[Export] protected NodePath entityPath;
		[Export] protected float health;
		[Export] public PackedScene lifeBar;
		[Export] private PackedScene packedSceneRadius;
		private Area2D radiusNode;

		public override void _Ready()
		{
			barCanvas = (CanvasLayer)lifeBar.Instance();
			SetBar(health);
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.CallDeferred("add_child", barCanvas);
			entity.Connect("ready", this, nameof(AdderRadius));
			entity.Connect("ready", this, nameof(AddConnect));
		}

		private void SetBar(float life)
		{
			barLife = barCanvas.GetChild<TextureProgress>(0);
			barLife.Value = life;
		}

		private void AdderRadius()
		{
			radiusNode = (Area2D)packedSceneRadius.Instance();
			var shapeInstanced = radiusNode.GetChild<CollisionShape2D>(0);
			var shapeEntity = entity.GetChild<CollisionShape2D>(0);
			shapeInstanced.Scale = shapeEntity.Scale;
			shapeInstanced.Shape = shapeEntity.Shape;
			entity.AddChild(radiusNode);
		}

		private void AddConnect()
		{
			radiusNode.Connect("area_entered", this, nameof(ShootEnter));
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