using Godot;

namespace Gestalt.Life
{
	public abstract class LifeBase : Node
	{
		private Area2D area2DCollision;
		protected KinematicBody2D Entity;
		[Export] private NodePath entityPath;
		[Export] protected float Health;
		[Export] protected float MaxHealth;
		[Export] private PackedScene packedSceneRadius;

		public override void _Ready()
		{
			Entity = GetNode<KinematicBody2D>(entityPath);
			Entity.Connect("ready", this, nameof(AddCollisionShape));
			Entity.Connect("ready", this, nameof(AddConnect));
		}

		private void AddCollisionShape()
		{
			area2DCollision = (Area2D)packedSceneRadius.Instance();
			var collisionShape = area2DCollision.GetChild<CollisionShape2D>(0);
			var entityShape = Entity.GetChild<CollisionShape2D>(0);
			collisionShape.Scale = entityShape.Scale;
			collisionShape.Shape = entityShape.Shape;
			Entity.AddChild(area2DCollision);
		}

		private void AddConnect()
		{
			area2DCollision.Connect("area_entered", this, nameof(ShootEnter));
		}

		protected abstract void GetDamage(float damage);

		public abstract void ShootEnter(Area2D bullet);

		protected void Death()
		{
			if (Health > 0) return;
			Entity.QueueFree();
		}
	}
}