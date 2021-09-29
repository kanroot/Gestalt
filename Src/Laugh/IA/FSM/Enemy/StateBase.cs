using Godot;
using Laugh.IA.Enemy;

namespace Laugh.IA.FSM.Enemy
{
	public class StateBase
	{
		protected Shoot shoot;
		protected MovementNode movement;
		public StateBase(NodePath shootPath)
		{
			shoot = shoot.GetNode<Shoot>(shootPath);
		}
	}
}