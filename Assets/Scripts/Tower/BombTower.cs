using Gameplay.Ennemies;

namespace Gameplay.Tower
{
    public class BombTower : BasicTower
    {
        protected override void IsIdle()
        {
            _animator.SetBool("IsAttacking", false);
        }

        protected override void ShootAt(Ennemy ennemy)
        {
            _animator.SetBool("IsAttacking", true);

            _SetArrow(ennemy);
        }

        private void _SetArrow(Ennemy ennemy)
        {
            var arrow = _poolArrow.GetAvailable<ProjectileBomb>();
            arrow.transform.position = transform.position;
            arrow.gameObject.SetActive(true);
            arrow.target = ennemy;
        }
    }
}