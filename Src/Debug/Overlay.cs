using Godot;
using Laugh.Shoots;
using Laugh.Shoots.CanShoots;

namespace Laugh.Debug
{
	public class Overlay : Control
	{
		private Label actual;
		[Export] private NodePath actualPath;
		[Export] private NodePath canMovePath;
		private Label cuentaSpawn;
		[Export] private NodePath cuentaSpwan;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		[Export] private NodePath shootPath;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			actual = GetNode<Label>(actualPath);
			cuentaSpawn = GetNode<Label>(cuentaSpwan);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			actual.Text = "Actual: " + entity.GlobalPosition;
			//cuentaSpawn.Text = $"N° Spwan: {canShootDemon.CountDivisionCircle.ToString()}";
		}
	}
}