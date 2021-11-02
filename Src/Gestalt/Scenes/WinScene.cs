using Godot;

namespace Gestalt.Scenes
{
	public class WinScene : Control
	{
		private Button buttonEndGame;

		public override void _Ready()
		{
			buttonEndGame = GetChild<Button>(2);
			buttonEndGame.Connect("pressed", this, nameof(QuitGame));
		}

		private void QuitGame()
		{
			GetTree().Quit();
		}
	}
}