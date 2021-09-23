using Godot;

namespace Laugh.Shoots.CanShoots
{
	public abstract class CanShootBase : Node
	{
		//PUNTO DE ORIGEN DE LA BALA
		protected Position2D BulletOrigin;

		//todos aquellos que puedan disparar por obligacion deben hacer referencia a una Scena de Bala
		[Export] protected PackedScene BulletScene;

		//CUERPO
		protected KinematicBody2D Entity;

		//CONTROLADORES DEL TIMER DEL DISPARO
		protected Timer TimerCanShoot;
		[Export] protected NodePath TimerPath;
		[Export] protected float TimeWait = 0.5f;
		[Export] public float SpeedBullet { get; set; }
		[Export] public bool CanShoot { get; set; }

		

		public override void _Ready()
		{
			TimerCanShoot = GetNode<Timer>(TimerPath);
			TimerCanShoot.WaitTime = TimeWait;
		}

		//cada cual vera como instanciar sus balas
		protected abstract void CreateBullet();
	}
}