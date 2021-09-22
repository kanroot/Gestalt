using Godot;
using Laugh.IA.FSM.Demon;
using Laugh.IA.FSM.PatternOfMovement;
using Laugh.Life;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA
{
	public class IADemon : IABase
	{
		private CanShootBase canShootBase;
		[Export] private NodePath canShootPath;

		private ChangePattern changePattern;

		//factor speedUp
		private LifeBase lifeBase;
		[Export] private NodePath lifePath;
		[Export] private NodePath movementAttackPath;
		private ShootAttack shootAttack;

		private MoveToPlayer moveToPlayer;

		public override void _Ready()
		{
			base._Ready();
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
			shootAttack = new ShootAttack(canShootBase);
			changePattern = new ChangePattern(canShootBase);
			moveToPlayer = new MoveToPlayer(entity, true, 300);
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
			moveToPlayer.PositionPlayer = player;
			moveToPlayer.CallMovement();
			ResetShapeSize();
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
			//movementAttack.OnExit();
		}
	}
}