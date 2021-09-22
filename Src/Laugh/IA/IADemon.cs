using Godot;
using Laugh.Life;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA
{
	public class IADemon : IABase
	{
		private CanShootBase canShootBase;
		[Export] private NodePath canShootPath;
		
		private LifeBase lifeBase;
		[Export] private NodePath lifePath;
		
		public override void _Ready()
		{
			base._Ready();
			canShootBase = GetNode<CanShootBase>(canShootPath);
			lifeBase = GetNode<LifeBase>(lifePath);
		}

		public override void ChangeStateOnEnter(KinematicBody2D player)
		{
			ResetShapeSize();
		}

		public override void ChangeStateOnExit(KinematicBody2D player)
		{
			//movementAttack.OnExit();
		}
		
	}
}