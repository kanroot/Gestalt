using Godot;

namespace Laugh.Life
{
    public class LifeBase : Node
    {
        [Export] protected int Life;
        [Export] protected NodePath EntityPath;
        private KinematicBody2D Entity;
        
        public override void _Ready()
        {
            Entity = GetNode<KinematicBody2D>(EntityPath);
        }
        
        //implementar como señal
        protected void Death()
        {
            if (Life > 0) return;
            Entity.QueueFree();
        }
        
        //implementar como señal
        protected void GrowingLife(int value)
        {
            Life += value;
        }
        
    }
}
