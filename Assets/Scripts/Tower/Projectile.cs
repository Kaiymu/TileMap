using Gameplay.Ennemies;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [HideInInspector]
    public Ennemy target = null;

    [SerializeField]
    protected int _damage = 1;

    [SerializeField]
    private float _speed = 5f;

    protected PoolSystem _poolArrow;

    private void Start()
    {
        _poolArrow = PoolSystem.instance;
    }

    private void Update()
    {
        if (target == null)
        {
            _poolArrow.PutBack(this);
            return;
        }

        _ArrowFollow();
    }

    private void _ArrowFollow()
    {
        var step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        var distanceEnnemy = Vector3.Distance(transform.position, target.transform.position);

        if (distanceEnnemy < 0.1f)
        {
            EnnemyTouched(target);
        }
    }
    protected virtual void EnnemyTouched(Ennemy ennemy)
    {
        _poolArrow.PutBack(this);
    }
}
