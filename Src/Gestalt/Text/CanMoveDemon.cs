using Godot;

namespace Gestalt.Text
{
	public class CanMoveDemon : CanMoveBody
	{
		[Export] private bool canInstance;
		private TransitionLevelOne transitionNode;

		[Export] private NodePath transitionNodePath;

		public override void _Ready()
		{
			base._Ready();
			transitionNode = GetNode<TransitionLevelOne>(transitionNodePath);
		}

		protected override void RotateBody(int degrees)
		{
			if (degrees > 180)
			{
				body.Rotate(DegreesToRadiant * -1);
				secondCount++;
			}

			if (secondCount < 360) return;
			if (canInstance) transitionNode.ChangeScene();
			count = 0;
			secondCount = 0;
		}
	}
}