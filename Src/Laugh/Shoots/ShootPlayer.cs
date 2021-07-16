using Godot;

namespace Laugh.Shoots
{
	public class ShootPlayer : Shoot
	{
		//propias
			//el spawn de las balas pasara por gestion propia del tipo de la bala, aunque podria gestionarlo el player
			// para dejar aún más limpio el codigo
		private Vector2 Movement { get; set; }
		private Vector2 MousePosition { get; set; }
		public override void _Ready()
		{
			Lifetime = 1;
			Speed = 15;
			GetTree().Root.AddChild(BulletFree);
			BulletFree.Start(Lifetime);
			MousePosition = GetLocalMousePosition();
		}


		public override void _PhysicsProcess(float delta)
		{
			Movement = Movement.MoveToward(MousePosition, delta);
			Movement = Movement.Normalized() * Speed;
			Position += Movement;
		}
		



	}
}