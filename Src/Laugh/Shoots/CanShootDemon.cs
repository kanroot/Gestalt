using System;
using Godot;

namespace Laugh.Shoots
{
	public class CanShootDemon : CanShootEnemy
	{
		private const float Circle = 360;
		[Export] private int countDivisionCircle = 3;
		//Para poder modificar la velocidad del patron
		[Export] public int DegreesRotate { get; set; }
		
		public bool CanRotateNode { get; set; }
		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("ready", this, nameof(CallerPosition));
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
			//por defecto puede rotar los spwan
			CanRotateNode = true;
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
		private void RotaryNode2D()
		{
			if (CanRotateNode != true) return;
			foreach (var originNode2d in ListPosition2d)
			{
				var degreesToRadiant = (Math.PI / 180) * DegreesRotate;
				originNode2d.Rotate((float)degreesToRadiant);
			}	
		}
		
	}
}