using Godot;

namespace Laugh.Shoots
{
	public class CanShootDemon : CanShootEnemy
	{
		private const float Circle = 360;
		[Export] private int countDivisionCircle = 3;
		
		//tener en consideracion que en futuros metodos debere bloquear la posibilidad de disparar y tendre que editar el ready y que se active bajo cierta señal
		public override void _Ready()
		{
			base._Ready();
			Entity.Connect("ready", this, nameof(CallerPosition));
			TimerCanShoot.Connect("timeout", this, nameof(CreateBullet));
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
			
			//parte en uno porque la posicion 0 de la lista debe mantener su posicion
			for (var i = 1; i != countDivisionCircle; i++)
			{
				ListPosition2d[i].RotationDegrees += angle * i;
			}
			
		}

		protected override void CreateBullet()
		{
			foreach (var originNode2d in ListPosition2d)
			{
				var bulletInstance = (ShootDemon) BulletScene.Instance();
				var position2d = originNode2d.GetChild<Position2D>(0);
				
				bulletInstance.Position = position2d.GlobalPosition;
				bulletInstance.RotationDegrees = originNode2d.RotationDegrees;
				
				var position2 = originNode2d.GetChild<Position2D>(1);
				bulletInstance.Direction = position2.GlobalPosition;
				GetTree().Root.AddChild(bulletInstance);
			}
		}
	}
}