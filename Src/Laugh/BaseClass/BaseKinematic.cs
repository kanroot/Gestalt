using GDMechanic.Wiring.Attributes;
using Godot;

namespace Laugh.BaseClass
{
	public class BaseKinematic : KinematicBody2D
	{ 
		//texto interior
		[Child] protected AnimatedSprite TextAnimated { get; set; } = new AnimatedSprite();
		[Export] protected float SpeedRotateText { get; set; } = (float) -0.008;
		
		// vida
		[Export] public float Health { get; set; } = 100;
		
		//movement
		[Export] public int Speed { get; set; } = 300;
		protected Vector2 DirectionKinematic { get; set; }
		
		//shoots
		[Node("Node2D/Position2D")] protected Position2D PositionShoot { get; set; } = new Position2D();
		//esta variable se cambia segun una señal de entrada el mouse o no en el cuerpo princial del asset
		[Child] protected Timer FireDelay { get; set;} = new Timer();
		[Export] public float FireDelayTime { get; set; } =  (float) 0.25;
		
		//posteriormente dentro de ciertas escenas no se podra disparar
		public bool CanFire { get; set; } = true;
		
		//posicion de disparo
		[Child] protected Node2D Node2D { get; set; } = new Node2D();
		
		//teoricamente podriamos cambiar la escena que esta insanciando
		public  PackedScene ShootCircle { get; set; } = 
			ResourceLoader.Load<PackedScene>("res://Src//Prefabs//ShootCircle.tscn");
		
		public override void _Process(float delta)
		{
			TextAnimated.Rotate(SpeedRotateText);
		}
		
		
		//gestor de la velocidad de disparo
		private void _on_Timer_timeout()
		{
			GD.Print("entre");
			CanFire = true;
		}
		

	}
}