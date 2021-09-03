using Godot;
using Laugh.IA.FSM.Demon;
using Laugh.Life;
using Laugh.Movement.Demon;
using Laugh.Shoots;

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
		private ShootAttack shootAttack;
		

		//movements 
		[Export()]private NodePath movementPath;

		public override void _Ready()
		{
			base._Ready();
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
			shootAttack = new ShootAttack(canShootBase);
			changePattern = new ChangePattern(canShootBase);
			
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
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