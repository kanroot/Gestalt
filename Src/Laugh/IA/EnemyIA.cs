using Godot;
using Laugh.IA.FSM;
using Laugh.Life;
using Laugh.Movement;
using Laugh.Shoots;

namespace Laugh.IA
{
	// ReSharper disable once InconsistentNaming
	public class EnemyIA : Node
	{
		//aceso a los otros sistemas
		[Export] private NodePath canMovePath;
		[Export] private NodePath canShootPath;
		[Export] private NodePath lifePath;

		private CanMoveBase canMoveBase;
		private CanShootBase canShootBase;
		private LifeBase lifeBase;

		//tiempo para cambiar el estado
		[Export] private float cooldown = 5;
		private float currentTime;

		//referencia a los estados
		private MovementAttackState movementAttackState;
		private ShootAttackState shootAttackState;
		private MovementAndShootState movementAndShootState;

		//Estado actual
		private State currenState;

		public override void _Ready()
		{
			canMoveBase = GetNode<CanMoveBase>(canMovePath);
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
			currentTime = 0;

			//inicializacion
			movementAndShootState = new MovementAndShootState(canMoveBase, canShootBase, null, lifeBase);
			shootAttackState = new ShootAttackState(canShootBase, movementAndShootState, lifeBase);
			movementAttackState = new MovementAttackState(canMoveBase, shootAttackState, lifeBase);
			//asignacion del estado inicial
			currenState = movementAttackState;
			//ENTRAMOS AL PRIMER ESTADO
			currenState.OnStateEnter();
		}

		//la funcion process se llama cada vez que pasa un frame
		public override void _Process(float delta)
		{
			if (currentTime >= cooldown)
			{
				currentTime = 0;
				if (currenState.ShouldTransition() && currenState.NextState != null )
				{
					TransitionTo(currenState.NextState);
				}
			}

			currentTime += delta;
		}

		private void TransitionTo(State state)
		{
			currenState.OnStateExit();
			currenState = state;
			currenState.OnStateEnter();
		}
	}
}