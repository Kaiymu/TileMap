namespace Gameplay.Ennemies
{
    public class EnnemyBrute : Ennemy
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
