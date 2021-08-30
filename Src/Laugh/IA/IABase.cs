using Godot;

namespace Laugh.IA
{
	public abstract class IABase : Node
	{
		private CollisionShape2D collisionShape2D;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		private Vector2 originalShape;

		[Export] private PackedScene packedSceneRadius;
		private Area2D radiusNode;
		[Export] private float scalesShape2D;
		private Timer timeToGroW;
		protected bool CanGrow { get; set; }

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			entity.Connect("ready", this, nameof(Callers));
			entity.Connect("ready", this, nameof(Connects));
			CanGrow = true;
		}

		private void Callers()
		{
			radiusNode = (Area2D)packedSceneRadius.Instance();
			entity.AddChild(radiusNode);
			collisionShape2D = radiusNode.GetChild<CollisionShape2D>(0);
			timeToGroW = radiusNode.GetChild<Timer>(1);
			originalShape = collisionShape2D.Scale;
		}

		private void Connects()
		{
			timeToGroW.Connect("timeout", this, nameof(GrowScaleCollisionShape));
			radiusNode.Connect("body_entered", this, nameof(ChangeStateOnEnter));
			radiusNode.Connect("body_exited", this, nameof(ChangeStateOnExit));
		}

		public abstract void ChangeStateOnEnter(KinematicBody2D player);

		public abstract void ChangeStateOnExit(KinematicBody2D player);

		private void GrowScaleCollisionShape()
		{
			if (CanGrow) collisionShape2D.Scale *= scalesShape2D;
		}

		protected void OriginalForm()
		{
			collisionShape2D.Scale = originalShape;
		}
	}
}