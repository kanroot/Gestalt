using Godot;
using Laugh.Shoots;

namespace Laugh.Debug
{
	public class Overlay : Control
	{
		private Label actual;

		[Export] private NodePath actualPath;
		[Export] private NodePath canMovePath;
		private CanShootDemon canShootDemon;
		private Label cuentaSpawn;
		[Export] private NodePath CuentaSpwan;
		private Label destino;
		private KinematicBody2D entity;
		[Export] private NodePath entityPath;
		[Export] private NodePath shootPath;

		public override void _Ready()
		{
			entity = GetNode<KinematicBody2D>(entityPath);
			actual = GetNode<Label>(actualPath);
			canShootDemon = GetNode<CanShootDemon>(shootPath);
			cuentaSpawn = GetNode<Label>(CuentaSpwan);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			actual.Text = "Actual: " + entity.GlobalPosition;
			cuentaSpawn.Text = $"N° Spwan: {canShootDemon.CountDivisionCircle.ToString()}";
		}
	}
}