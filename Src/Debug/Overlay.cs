using Godot;
using System;
using Laugh.Movement;
using Laugh.Shoots;

public class Overlay : Control
{
	private Label actual;
	private Label destino;
	private Label distancia;
	private Label cuentaSpawn;
	
	[Export] private NodePath actualPath;
	[Export] private NodePath destinoPath;
	[Export] private NodePath distanciaPath;
	[Export] private NodePath CuentaSpwan;
	private KinematicBody2D entity;
	[Export] private NodePath entityPath;
	[Export] private NodePath canMovePath;
	[Export] private NodePath shootPath;
	private CanMoveDemon canMoveDemon;
	private CanShootDemon canShootDemon;
	
    public override void _Ready()
    {
	    entity = GetNode<KinematicBody2D>(entityPath);
	    actual = GetNode<Label>(actualPath);
	    destino = GetNode<Label>(destinoPath);
	    distancia = GetNode<Label>(distanciaPath);
	    canMoveDemon = GetNode<CanMoveDemon>(canMovePath);
	    canShootDemon = GetNode<CanShootDemon>(shootPath);
	    cuentaSpawn = GetNode<Label>(CuentaSpwan);
    }

    public override void _Process(float delta)
    {
	    base._Process(delta);
	    actual.Text = "Actual: " + entity.GlobalPosition;
	    destino.Text = "Destino:" + canMoveDemon.positionPlayer;
	    distancia.Text = $"Distancia {entity.GlobalPosition.DistanceTo(canMoveDemon.positionPlayer).ToString()}";
	    cuentaSpawn.Text = $"N° Spwan: {canShootDemon.CountDivisionCircle.ToString()}";
    }
}
