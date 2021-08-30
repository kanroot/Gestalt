using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots
{
	public abstract class CanShootEnemy : CanShootBase
	{
		//cantidad de nodos con los cuales dispara, sea uno o más
		protected readonly List<Node2D> ListPosition2d = new List<Node2D>();

		//Scena a instanciar
		[Export] protected PackedScene RotatePosition2d;

		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("ready", this, nameof(CallerPosition));
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
		}

		public abstract void CallerPosition();
	}
}