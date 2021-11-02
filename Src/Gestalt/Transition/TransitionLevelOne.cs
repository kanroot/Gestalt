using Godot;

public class TransitionLevelOne : Node
{
	[Export] private PackedScene LevelOne;

	public override void _Ready()
	{
	}

	public void ChangeScene()
	{
		GetTree().ChangeScene(LevelOne.ResourcePath);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}