using System;
using Godot;

namespace Laugh.Shoots
{
	public class CanShootDemon : CanShootEnemy
	{
		private const float Circle = 360;
		[Export] private int countDivisionCircle = 3;
		[Export] private int degreesRotate;
		

		//tener en consideracion que en futuros metodos debere bloquear la posibilidad de disparar y tendre que editar el ready y que se active bajo cierta señal
		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("ready", this, nameof(CallerPosition));
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
		}

		public override void _PhysicsProcess(float delta)
		{
			RotaryNode2D();
		}

		private void CallerPosition()
		{
			CreatePosition();
			ModifyPosition2d();
		}

		private void CreatePosition()
		{
			for (var i = 0; i < countDivisionCircle; i++)
			{
				var position2d = (Node2D)RotatePosition2d.Instance();
				ListPosition2d.Add(position2d);
				Entity.AddChild(position2d);
				position2d.LookAt(Vector2.Up);
			}
		}

		private void ModifyPosition2d()
		{
			var angle = Circle / countDivisionCircle;
			//parte en uno debido a la posicion 0 de la lista la cual debe mantener su posicion
			for (var i = 1; i != countDivisionCircle; i++)
			{
				ListPosition2d[i].RotationDegrees += angle * i;
			}
		}

		protected override void CreateBullet()
		{
			if (Canfire != true) return;
			foreach (var originNode2d in ListPosition2d)
			{
				var bulletInstance = (ShootDemon)BulletScene.Instance();
				var position2d = originNode2d.GetChild<Position2D>(0);
				bulletInstance.Position = position2d.GlobalPosition;
				bulletInstance.RotationDegrees = originNode2d.RotationDegrees;
				GetTree().Root.AddChild(bulletInstance);
			}
		}
		//implementar metodo giratorio
		private void RotaryNode2D()
		{
			foreach (var originNode2d in ListPosition2d)
			{
				var degreesToRadiant = (Math.PI / 180) * degreesRotate;
				originNode2d.Rotate((float)degreesToRadiant);
			}	
		}
		
		//implementar el patron state
		//LLamar o desactivar via timer ?
		//implementar metodo respiratorio, que llame y aumente la cantidad de spwan bullet
		//implementar un metodo que evite el movimiento
	}
}