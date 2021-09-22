using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots.CanShoots
{
	public abstract class CanShootEnemy : CanShootBase
	{
		//cantidad de nodos con los cuales dispara, sea uno o más
		protected List<Node2D> ListPosition2d;

		//Scena a instanciar
		[Export] protected PackedScene RotatePosition2d;

		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("ready", this, nameof(AddNodeSpawnBullet));
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
		}

		public abstract void AddNodeSpawnBullet();

		public abstract void KillNodes();
	}
}