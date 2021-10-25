using System;
using System.Collections.Generic;
using Godot;

namespace Gestalt.Ending
{
	public class Ending : Control
	{
		private readonly Random rnd = new Random();
		private HBoxContainer containerText;
		private readonly List<string> endingText = new List<string>();
		private int height;
		private readonly List<Vector2> linesDestiny = new List<Vector2>();
		private readonly List<Vector2> linesFrom = new List<Vector2>();
		private Label textEnding;
		private Vector2 viewport;
		private int width;

		public override void _Ready()
		{
			containerText = GetChild<HBoxContainer>(1);
			textEnding = containerText.GetChild<Label>(0);
			ChoseText();
			viewport = GetViewport().Size;
			height = (int)viewport.y;
			width = (int)viewport.x;
		}


		public override void _Process(float delta)
		{
			CreateLines();
		}

		private void CreateLines()
		{
			var from = new Vector2(0, rnd.Next(0, height));
			var destiny = new Vector2(width, rnd.Next(0, height));
			linesFrom.Add(from);
			linesDestiny.Add(destiny);
		}

		public override void _Draw()
		{
			for (var i = 0; i < linesFrom.Count; i++) DrawLine(linesFrom[i], linesDestiny[i], new Color(1, 1, 1));
		}


		private void ChoseText()
		{
			SetText();
			var selector = rnd.Next(0, endingText.Count);
			textEnding.Text = endingText[selector];
		}

		private void SetText()
		{
			endingText.Add("END GAME ?");
			endingText.Add("NO MATTER WHERE YOU GO,\n EVERYONE'S CONNECTED");
			endingText.Add("* STATIC NOISES *");
			endingText.Add("GET OVER IT (?)");
		}
	}
}