using Godot;
using Laugh.IA.Enemy;

namespace Laugh.Life
{
	public class LifeBase : Node
	{
		private CanvasLayer barCanvas;
		private KinematicBody2D entity;
		[Export] protected NodePath entityPath;
		[Export] protected float health;
		[Export] public PackedScene lifeBar;
		[Export] private PackedScene packedSceneRadius;
		private Area2D radiusNode;

		public override void _Ready()
		{
			barCanvas = (CanvasLayer)lifeBar.Instance();
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.CallDeferred("add_child", barCanvas);
			entity.Connect("ready", this, nameof(Adder));
			entity.Connect("ready", this, nameof(AddConnect));
		}

		private void Adder()
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
			radiusNode.Connect("body_entered", this, nameof(ShootEnter));
			radiusNode.Connect("body_exited", this, nameof(ChangeStateOnExit));
		}

		public void GetDamage(float damage)
		{
			health -= damage;
		}

		public void ShootEnter(Area2D bullet)
		{
			
		}

		public void ChangeStateOnExit(Area2D bullet)
		{
		}


		//implementar como señal
		protected void Death()
		{
			if (health > 0) return;
			entity.QueueFree();
		}
		
		protected void GrowingLife(int value)
		{
			health += value;
		}
	}
}