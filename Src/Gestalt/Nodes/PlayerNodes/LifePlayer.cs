using Gestalt.Bullets;
using Gestalt.Life;
using Godot;

namespace Gestalt.Nodes.PlayerNodes
{
    public class LifePlayer : LifeBase
    {
        [Export() ]private PackedScene lifePlayer;
        private CanvasLayer barCanvas;
        private TextureProgress barLife;
        private VBoxContainer vBoxContainer;
        
        public override void _Ready()
        {
            base._Ready();
            barCanvas = (CanvasLayer)lifePlayer.Instance();
            GetChild();
            SetBarLife(Health, MaxHealth);
            Entity.CallDeferred("add_child", barCanvas);
        }
        
        private void GetChild()
        {
            vBoxContainer = barCanvas.GetChild<VBoxContainer>(0);
            barLife = vBoxContainer.GetChild<TextureProgress>(1);
        }

        public override void ShootEnter(Area2D bullet)
        {
            if (!bullet.GetGroups().Contains("shootEnemy")) return;
            var bulletEnemy = (BulletBase) bullet;
            GetDamage(bulletEnemy.Damage);
        }
        
        private void SetBarLife(float currentLife)
        {
            barLife.Value = currentLife;
        }

        private void SetBarLife(float currentLife, float maxLife)
        {
            barLife.MaxValue = maxLife;
            barLife.Value = currentLife;
        }

        protected override void GetDamage(float damage)
        {
            Health -= damage;
            SetBarLife(Health);
        }
        
    }
}
