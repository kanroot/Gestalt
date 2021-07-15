using Godot;

namespace Laugh.Shoots
{
    public class ShootDemon : Shoot
    {
        
        public override void _Ready()
        {
            Lifetime = 10;
            Speed = 150;
            GetTree().Root.AddChild(BulletFree);
            BulletFree.Autostart = true;
        }
        
        public override void _PhysicsProcess(float delta)
        {
            Position += Transform.x * Speed * delta;
        }

    }
}
