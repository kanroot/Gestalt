using System;
using Godot;

namespace Gestalt.IA.FSM.Enemy
{
	public class ShurikenBounce : StateBase
	{
		public ShurikenBounce(NodePath shootPath, NodePath movementPath, PackedScene spawn, int countSpawn,
			PackedScene bullet, float speedBullet, KinematicBody2D entity, int directionToRotation, int degreesRotate) :
			base(shootPath, movementPath, spawn, countSpawn, bullet, speedBullet, entity, directionToRotation,
				degreesRotate)
		{
		}

		public override void OnEnter()
		{
			//NodeShoot.SetShootBase();
		}

		public override void OnExit()
		{
			throw new NotImplementedException();
		}
	}
}