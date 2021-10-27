using System;
using System.Collections.Generic;
using Godot;

namespace Gestalt.Ending
{
	public class Ending : Control
	{
		private readonly List<string> endingText = new List<string>();
		private readonly List<Vector2> linesDestiny = new List<Vector2>();
		private readonly List<Vector2> linesFrom = new List<Vector2>();
		private readonly Random rnd = new Random();
		private Button buttonMain;
		private HBoxContainer containerText;
		private int count;
		private TextureRect gestalt;
		private int height;
		private Label textEnding;
		private Vector2 viewport;
		private int width;
		[Export] public int DeathCount { get; set; }

		public override void _Ready()
		{
			GetChild();
			ScreenSize();
			ChoseImageOrText();
			count = 0;
		}

		private void GetChild()
		{
			containerText = GetChild<HBoxContainer>(1);
			gestalt = GetChild<TextureRect>(2);
			buttonMain = GetChild<Button>(3);
			textEnding = containerText.GetChild<Label>(0);
			AddConnections();
		}

		private void AddConnections()
		{
			buttonMain.Connect("pressed", this, nameof(Textprueba));
		}

		private void Textprueba()
		{
			GD.Print("wuea" +
			         "");
		}

		private void ScreenSize()
		{
			viewport = GetViewport().Size;
			height = (int)viewport.y;
			width = (int)viewport.x;
		}

		private void ChoseImageOrText()
		{
			if (DeathCount < 100)
			{
				SetText();
				var selector = rnd.Next(0, endingText.Count);
				textEnding.Text = endingText[selector];
				containerText.Alignment = BoxContainer.AlignMode.Center;
			}
			else
			{
				gestalt.Visible = true;
			}
		}

		public override void _Process(float delta)
		{
			if (count > DeathCount) return;
			CreateLines();
		}


		private void CreateLines()
		{
			count += 1;
			var from = new Vector2(0, rnd.Next(0, height));
			var destiny = new Vector2(width, rnd.Next(0, height));
			linesFrom.Add(from);
			linesDestiny.Add(destiny);
			Update();
		}

		public override void _Draw()
		{
			for (var i = 0; i < linesFrom.Count; i++) DrawLine(linesFrom[i], linesDestiny[i], new Color(1, 1, 1));
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