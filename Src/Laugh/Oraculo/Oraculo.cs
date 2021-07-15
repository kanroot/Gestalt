using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;

namespace Laugh.Oraculo
{
	public class Oraculo : KinematicBody2D
	{
		[Export] private float speedRotateBody = (float) -0.008;
		[Export] private float speedOutside = (float) 0.004;
		[Child] private AnimatedSprite body;
		[Child] private AnimatedSprite outside;

		public override void _Ready()
		{
			this.Wire();
		}

		public override void _Process(float delta)
		{
			outside.Rotate(speedRotateBody);
			body.Rotate(speedOutside);
		}
	}
}