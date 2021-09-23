using Godot;
using Laugh.Life;
using Laugh.Shoots.CanShoots;

namespace Laugh.IA
{
	public class IADemon : IABase
	{
		
		public override void _Ready()
		{
			base._Ready();
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