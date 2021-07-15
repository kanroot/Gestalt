using System.Threading.Tasks;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;
using Laugh.Shoots;

namespace Laugh.Player
{
	public class Player : KinematicBody2D
	{
		//cuerpo y giro
		[Export] private float speedRotateText = (float) -0.008;
		[Export] private float speedRotateLine = (float) (-0.008 / 0.5);
		[Child] private AnimatedSprite textAnimated;
		[Child] private AnimatedSprite lineOutside;

		// vida
		[Export] public float Health { get; set; } = 100;

		//movement
		[Export] public int Speed { get; set; } = 300;
		private Vector2 directionPlayerVector;

		//shoots
		//esta variable se cambia segun una señal de entrada el mouse o no en el cuerpo princial del asset
		[Child] private Timer fireDelay;
		[Export] private float fireDelayTime = (float) .25;

		//posteriormente dentro de ciertas escenas no se podra disparar
		public bool CanFire { get; set; } = true;

		//posicion de disparo
		[Child] private Node2D node2D;
		private readonly PackedScene shootCircle =
			ResourceLoader.Load<PackedScene>("res://Src//Prefabs//ShootCircle.tscn");


		public override void _Ready()
		{
			this.Wire();
			TimeShoot();
		}


		public override void _Process(float delta)
		{
			textAnimated.Rotate(speedRotateText);
			lineOutside.Rotate(speedRotateLine);
			//usado para que position2d gire entorno a la posicion del mouse
			node2D.LookAt(GetGlobalMousePosition());
			GetInputFire();
		}

		private void TimeShoot()
		{
			//cuando llega a 0, la funcion Oneshot vuelve a reiniciar el contador si es 0
			fireDelay.OneShot = false;
			fireDelay.WaitTime = fireDelayTime;
			//creo una instancia de timer
			fireDelay.Start();
		}


		private void GetInputFire()
		{
			if (!Input.IsActionPressed("Fire") || CanFire == false) return;
			var bulletInstance = (ShootPlayer) shootCircle.Instance();
			if (bulletInstance == null) return;
			var position2D = (Position2D) node2D.GetChild(0);
			bulletInstance.Position = position2D.GlobalPosition;
			GetTree().Root.AddChild(bulletInstance);
			CanFire = false;
		}


		//gestor de la velocidad de disparo
		private void _on_Timer_timeout()
		{
			CanFire = true;
		}


		//preguntar por el manejo de señales
		//Detecta cuando el mouse entra al cuerpo
		private void _on_Player_mouse_entered()
		{
			CanFire = false;
		}

		private void _on_Player_mouse_exited()
		{
			CanFire = true;
		}

		private Vector2 GetInputMovement()
		{
			directionPlayerVector = new Vector2();

			if (Input.IsActionPressed("ui_right"))
				directionPlayerVector.x += 1;

			if (Input.IsActionPressed("ui_left"))
				directionPlayerVector.x -= 1;

			if (Input.IsActionPressed("ui_down"))
				directionPlayerVector.y = 1;

			if (Input.IsActionPressed("ui_up"))
				directionPlayerVector.y -= 1;

			return directionPlayerVector *= Speed;
		}

		public override void _PhysicsProcess(float delta)
		{
			MoveAndSlide(GetInputMovement());
		}

		//TODO
		// procedimiento para generacion prodecural
		// tarea 1, diseñar una habitacion para comprobar comportamiento dentro de margenes LISTO
		// Dar comportamiento a los enemigos aleatorios 

		// patron finite state machine (fcm, darle una mirada para darle estados al enemigo)
		// Estado basico perseguidor // perseguido  al enemigo
		// las transiciones estan condicionadas, no pueden cambiar sin una previa señal de algo
		// animacion

		// vida
		//comprobar la vida y cambiar el sprite segun esa variable (metodo)

		// tile map
		// habitaciones como escenas independientes (Margenes manuales, layout)
		// otro tile map que represente objetos (hacer un script, que encuentre todos los tiles, y genere procedural)
		// poder mapear, bloques de pared
		// pensar algoritmo


		//crear assest de suelo, invisible
	}
}