using Gestalt.Movements;
using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.Nodes.EnemyNodes
{
	[RegisteredType(nameof(MovementNode))]
	public class MovementNode : Node
	{
		private MovementBase movementPattern;
		[Export] public bool CanMove { get; set; }

		public void SetPattern(MovementBase pattern)
		{
			movementPattern = pattern;
		}

		public override void _Process(float delta)
		{
			if (CanMove == false) return;
			movementPattern.DoMovement(delta);
		}
	}
}