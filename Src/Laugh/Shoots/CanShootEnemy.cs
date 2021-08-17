using System.Collections.Generic;
using Godot;

namespace Laugh.Shoots
{
	public abstract class CanShootEnemy : CanShootBase1
	{
		//cantidad de nodos con los cuales dispara, sea uno o más
		protected readonly List<Node2D> ListPosition2d = new List<Node2D>();
		//Scena a instanciar
		[Export] protected PackedScene RotatePosition2d;
	}
}