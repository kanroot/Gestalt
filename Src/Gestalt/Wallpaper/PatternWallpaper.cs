using System;
using System.Collections.Generic;
using Godot;
using Array = Godot.Collections.Array;

namespace Gestalt.Wallpaper
{
	public class PatternWallpaper : Node2D
	{
		private readonly int degreesRotate = 1;
		private readonly List<Sprite> sprite = new List<Sprite>();
		private Array arraySprite;
		private float radiant;

		public override void _Ready()
		{
			arraySprite = GetChildren();
			foreach (Sprite s in arraySprite) sprite.Add(s);
			radiant = (float)(Math.PI / 180 * degreesRotate);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			PatterTwo();
		}

		private void PatternOne()
		{
			RotateSprites(1);
		}


		private void PatterTwo()
		{
			RotateSprites(-1);
		}

		private void RotateSprites(int dir)
		{
			for (var i = 0; i < sprite.Count; i++) sprite[i].Rotate(radiant / (i + 1) * dir);
		}
	}
}