namespace Gameplay.Ennemies
{
    public class EnnemyRunner : Ennemy
    {
        protected override void Move()
        {
            base.Move();
            _ennemyAnimator.SetBool("IsAttacking", false);
        }

        protected override void Attack()
        {
            base.Attack();
            _ennemyAnimator.SetBool("IsAttacking", true);
        }

        protected override void Death()
        {
            base.Death();
            _ennemyAnimator.SetBool("IsDead", true);
        }
    }
}
