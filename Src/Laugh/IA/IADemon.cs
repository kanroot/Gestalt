using Godot;
using Laugh.Life;
using Laugh.Movement;
using Laugh.Shoots;

namespace Laugh.IA.FSM.Demon
{
	public class IADemon : IABase
	{
		private CanMoveBase canMoveBase;

		//aceso a los otros sistemas
		[Export] private NodePath canMovePath;
		private CanShootBase canShootBase;
		[Export] private NodePath canShootPath;
		private ChangePattern changePattern;

		private int counState;

		//factor speedUp
		private LifeBase lifeBase;
		[Export] private NodePath lifePath;

		private MoveAttack moveAttack;
		private ShootAttack shootAttack;

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
			//changePattern.ChangePatterns();
			//canShootBase.Canfire = false;
			// changePattern.OnExit();
			// moveAttack.OnEnter();
			// CanGrow = false;
			// OriginalForm();
			// if (counState <= 1) return;
			// moveAttack.OnExit();
			// counState = 0;
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
			// CanGrow = true;
			// shootAttack.OnEnter();
			// counState++;
		}
	}
}