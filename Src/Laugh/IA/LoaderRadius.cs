using Godot;

namespace Laugh.IA
{
    public class LoaderRadius : Node
    {

        [Export()] private PackedScene sceneRadiusArea;
        [Export()] private NodePath entityPath;
        private KinematicBody2D entity;
        public override void _Ready()
        {
            entity = GetNode<KinematicBody2D>(entityPath);
            entity.Connect("ready", this, nameof(CallerRadius));
        }

        private void CallerRadius()
        {
            var areaRadius =  (Area2D) sceneRadiusArea.Instance();
            entity.AddChild(areaRadius);
        }
    }
}
