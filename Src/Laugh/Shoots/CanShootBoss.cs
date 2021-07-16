using System;
using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots
{
	public class CanShootBoss : Node
	{

		private KinematicBody2D entity;
		
		[Export] private int countDivisionCircle = 3;
		private const float Circle = 360;

		[Export]
		private PackedScene rotatePosition2d;
		
		private List<Node2D> listPosition2d = new List<Node2D>();
		
		public override void _Ready()
		{
			entity = GetParent<KinematicBody2D>();
			entity.Connect("ready",this, nameof(CallerPosition) );
		}

		private void CallerPosition()
		{
			CreatePosition();
			ModifyPosition2d();
		}
		private void CreatePosition()
		{
			for (int i = 0; i < countDivisionCircle; i++)
			{
				var position2d = (Node2D) rotatePosition2d.Instance();
				listPosition2d.Add(position2d);
				entity.AddChild(position2d);
				position2d.LookAt(Vector2.Up);
			}
		}

		private void ModifyPosition2d()
		{
			var angle = (Circle / countDivisionCircle);
			for (int i = 1; i != countDivisionCircle; i++)
			{
				listPosition2d[i].RotationDegrees += angle * i;
			}
			
		}

	}
}