using Godot;

namespace Laugh.IA
{
	public abstract class AreaDetectBase : Area2D
	{
		private Timer timeToGroW;
		private CollisionShape2D collisionShape2D;
		private new Vector2 originalShape;
		[Export] private float factorScale;
		protected bool CanGrow { get; set; }

		public override void _Ready()
		{
			collisionShape2D = GetChild<CollisionShape2D>(0);
			timeToGroW = GetChild<Timer>(1);
			timeToGroW.Connect("timeout", this, nameof(GrowScaleCollisionShape));
			originalShape = collisionShape2D.Scale;
			Connect("body_entered", this, nameof(ChangeStateOnEnter));
			Connect("body_exited", this, nameof(ChangeStateOnExit));
			CanGrow = true;
		}

		public abstract void ChangeStateOnEnter(KinematicBody2D player);

		public abstract void ChangeStateOnExit(KinematicBody2D player);
		private void GrowScaleCollisionShape()
		{
			if (CanGrow)
			{
				collisionShape2D.Scale *= factorScale;
			}
		}

		protected void OriginalForm()
		{
			collisionShape2D.Scale = originalShape;
		}


	}
}
