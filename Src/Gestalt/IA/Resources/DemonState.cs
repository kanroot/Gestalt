using Godot;
using MonoCustomResourceRegistry;

namespace Gestalt.IA.Resources
{
	[RegisteredType(nameof(DemonState))]
	public class DemonState : Resource
	{
		[Export()] public PackedScene Spawn;
		[Export()] public PackedScene Bullet;
		[Export()] public int CountNodes;
		[Export()] public int SpeedBullet;
		[Export()] public int Degrees;
		[Export()] public int Direction;
		[Export()] public int SpeedMovement;
		
	}
}