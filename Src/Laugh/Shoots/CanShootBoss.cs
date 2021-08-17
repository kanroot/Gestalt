using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots
{
	public class CanShootBoss : Node
	{
		private const float Circle = 360;

		[Export] private PackedScene bulletBoss;

		[Export] private int countDivisionCircle = 3;

		private KinematicBody2D entity;

		private readonly List<Node2D> listPosition2d = new List<Node2D>();

		[Export] private PackedScene rotatePosition2d;

		private Timer timerCanShoot;

		//tiempo de lanzamiento de cada vala
		[Export] private NodePath timerPath;
		[Export] private float timeWait = 0.5f;

		public override void _Ready()
		{
			entity = GetParent<KinematicBody2D>();
			entity.Connect("ready", this, nameof(CallerPosition));
			timerCanShoot = GetNode<Timer>(timerPath);
			timerCanShoot.Connect("timeout", this, nameof(CreateBullet));
			timerCanShoot.WaitTime = timeWait;
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
				var position2d = (Node2D)rotatePosition2d.Instance();
				listPosition2d.Add(position2d);
				entity.AddChild(position2d);
				position2d.LookAt(Vector2.Up);
			}
		}

		private void ModifyPosition2d()
		{
			var angle = Circle / countDivisionCircle;
			for (var i = 1; i != countDivisionCircle; i++) listPosition2d[i].RotationDegrees += angle * i;
		}

		private void CreateBullet()
		{
			foreach (var originBullet in listPosition2d)
			{
				var bulletInstance = (Shoot)bulletBoss.Instance();
				var position2d = originBullet.GetChild<Position2D>(0);
				bulletInstance.Position = position2d.GlobalPosition;
				GetParent().AddChild(bulletInstance);
			}
		}
	}
}