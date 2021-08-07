using Gameplay.Ennemies;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBomb : Projectile
{
    [SerializeField]
    private float _radiusExplosion = 1f;

    [SerializeField]
    private GameObject _explosionEffect;

    protected override void EnnemyTouched(Ennemy ennemy)
    {
        base.EnnemyTouched(ennemy);
        _EnnemiesTouched();
    }

    private void _EnnemiesTouched()
    {
        var activeEnnemies = GameManager.instance.GetActiveEnnemies();
        for (int i = 0; i < activeEnnemies.Count; i++)
        {
            var ennemies = activeEnnemies[i];

            var distanceEnnemy = Vector3.Distance(transform.position, ennemies.transform.position);

            if (distanceEnnemy < _radiusExplosion)
            {
                ennemies.Damage(_damage);
            }
        }

        var explosionEffect = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffect.gameObject, 0.3f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radiusExplosion);
    }
}
