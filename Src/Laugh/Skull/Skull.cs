using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;
using Godot;
using Laugh.BaseClass;
using Laugh.Player;

namespace Laugh.Skull
{
	public class Skull : BaseKinematic
	{
		public override void _Ready()
		{
			this.Wire();
		}
	}
}