using Godot;

namespace Gestalt.Scenes
{
    public class Main : Control
    {
        [Export()]private PackedScene levelOne;
        private VBoxContainer buttons;
        private Button play;
        private Button exit;
        
        public override void _Ready()
        {
           
            buttons = GetChild<VBoxContainer>(1);
            play = buttons.GetChild<Button>(0);
            exit = buttons.GetChild<Button>(1);
            play.Connect("pressed", this, nameof(ChangeToLevelOne));
            exit.Connect("pressed", this, nameof(CloseGame));
        }

        private void ChangeToLevelOne()
        {
            GetTree().ChangeScene(levelOne.ResourcePath);
        }

        private void CloseGame()
        {
            GetTree().Quit();
        }


    }
}
