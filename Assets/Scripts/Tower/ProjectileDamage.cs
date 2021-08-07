using Gameplay.Ennemies;

public class ProjectileDamage : Projectile
{
    protected override void EnnemyTouched(Ennemy ennemy)
    {
        base.EnnemyTouched(ennemy);
        target.Damage(_damage);
    }
}
