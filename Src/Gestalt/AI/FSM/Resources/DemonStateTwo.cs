using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.AI.FSM.Resources
{
	[RegisteredType(nameof(DemonStateTwo))]
	public class DemonStateTwo : DemonState
	{
		[Export()] public PackedScene Radius;
		[Export()] public float ScaleOfAreaDetect;
	}
}