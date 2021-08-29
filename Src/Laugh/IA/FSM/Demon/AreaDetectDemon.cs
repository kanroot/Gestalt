using Godot;
using Laugh.IA.FSM.Demon;
using Laugh.Life;
using Laugh.Movement;
using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class AreaDetectDemon : AreaDetectBase
	{
		//aceso a los otros sistemas
		[Export] private NodePath canMovePath;
		[Export] private NodePath canShootPath;
		[Export] private NodePath lifePath;

		private CanMoveBase canMoveBase;
		private CanShootBase canShootBase;
		private LifeBase lifeBase;

		private MoveAttack moveAttack;
		private ShootAttack shootAttack;
		private ChangePattern changePattern;

		private int counState = 0;

		//por el momento un timer que evita que salga 
		private Timer timerChangeState = new Timer();

		public override void _Ready()
		{
			base._Ready();
			//PROPIO DEL DEMON
			canMoveBase = GetNode<CanMoveBase>(canMovePath);
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
			moveAttack = new MoveAttack(canMoveBase);
			shootAttack = new ShootAttack(canShootBase);
			changePattern = new ChangePattern(canShootBase);
			changePattern.OnEnter();
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
			changePattern.OnExit();
			moveAttack.OnEnter();
			CanGrow = false;
			OriginalForm();
			if (counState <= 1) return;
			moveAttack.OnExit();
			counState = 0;
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
			CanGrow = true;
			shootAttack.OnEnter();
			counState++;
		}
	}
}