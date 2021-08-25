using Godot;

namespace Laugh.IA
{
	public class AreaDetect : Area2D
	{
		private Timer timeToGroW;
		private CollisionShape2D collisionShape2D;
		private new Vector2 originalShape;
		[Export] private float factorScale;
		
		public override void _Ready()
		{
			collisionShape2D = GetChild<CollisionShape2D>(0);
			timeToGroW = GetChild<Timer>(1);
			timeToGroW.Connect("timeout", this, nameof(GrowScaleCollisionShape));
			originalShape = collisionShape2D.Scale;
			Connect("area_entered", this, nameof(ChangeState));
		}
		
		public void ChangeState(Area2D player)
		{
			
		}
		
		private void GrowScaleCollisionShape()
		{
			GD.Print(collisionShape2D.Scale.ToString());
			collisionShape2D.Scale *= factorScale;
		}

		
	}
}
