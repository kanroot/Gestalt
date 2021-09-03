using Godot;
using Laugh.IA.FSM.Demon;
using Laugh.Life;
using Laugh.Movement;
using Laugh.Shoots;

namespace Laugh.IA
{
	public class IADemon : IABase
	{
		private CanMoveDemon canMoveDemon;

		//aceso a los otros sistemas
		[Export] private NodePath canMovePath;
		private CanShootBase canShootBase;
		[Export] private NodePath canShootPath;
		private ChangePattern changePattern;

		//factor speedUp
		private LifeBase lifeBase;
		[Export] private NodePath lifePath;

		private MoveAttack moveAttack;
		private ShootAttack shootAttack;

		public override void _Ready()
		{
			base._Ready();
			canMoveDemon = GetNode<CanMoveDemon>(canMovePath);
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
			moveAttack = new MoveAttack(canMoveDemon);
			shootAttack = new ShootAttack(canShootBase);
			changePattern = new ChangePattern(canShootBase);
			changePattern.OnEnter();
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
			changePattern.OnExit();
			moveAttack.AttackPlayer(player);
			ResetShapeSize();
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
			// CanGrow = true;
			// shootAttack.OnEnter();
			// counState++;
		}
	}
}