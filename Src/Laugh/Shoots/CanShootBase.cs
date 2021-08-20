using Godot;

namespace Laugh.Shoots
{
	public abstract class CanShootBase : Node
	{
		//CUERPO
		protected KinematicBody2D Entity;

		//todos aquellos que puedan disparar por obligacion deben hacer referencia a una Scena de Bala
		[Export] protected PackedScene BulletScene;

		//PUNTO DE ORIGEN DE LA BALA
		protected Position2D BulletOrigin;

		//CONTROLADORES DEL TIMER DEL DISPARO
		protected Timer TimerCanShoot;
		[Export] public bool Canfire { get; set; }
		[Export] protected NodePath TimerPath;
		[Export] protected float TimeWait = 0.5f;

		public override void _Ready()
		{
			Entity = GetParent<KinematicBody2D>();
			TimerCanShoot = GetNode<Timer>(TimerPath);
			TimerCanShoot.WaitTime = TimeWait;
		}

		//cada cual vera como instanciar sus balas
		protected abstract void CreateBullet();
	}
}