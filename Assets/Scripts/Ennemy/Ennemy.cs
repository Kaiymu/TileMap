using PoolSystem.Runtime;
using UnityEngine;

namespace Gameplay.Ennemies
{
    public abstract class Ennemy : MonoBehaviour
    {
        // TODO Changer ça.
        [HideInInspector]
        public Waypoint waypoint;
       
        [SerializeField]
        private EnnemyData _ennemyData;

        // Reset leur vâleurs, via scriptable object :')
        protected int _HP = 10;
        protected int _damage = 1;
        protected float _speed = 1f;
        protected float _range = 0.1f;
        protected float _attackSpeed = 0.5f;

        [SerializeField]
        protected HealthBar _healthBar;

        protected PoolManager _poolEnnemy;
        protected Animator _ennemyAnimator;

        private SpriteRenderer _spriteRenderer;
        private float _attackSpeedDelta = 0f;

        private void Awake()
        {
            _ennemyAnimator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _poolEnnemy = PoolManager.instance;
        }

        private void OnEnable()
        {
            _HP = _ennemyData.HP;
            _damage = _ennemyData.damage;
            _speed = _ennemyData.speed;
            _range = _ennemyData.range;
            _attackSpeed = _ennemyData.attackSpeed;
            _attackSpeedDelta = 0f;

            GameManager.instance.ennemyList.Add(this);
            _healthBar.SetMaxValue(_HP);
        }

        private void OnDisable()
        {
            GameManager.instance.ennemyList.Remove(this);
        }

        private void Update()
        {
            if (waypoint)
            {
                var distanceWaypoint = Vector3.Distance(transform.position, waypoint.transform.position);

                if (distanceWaypoint < _range)
                {
                    if (waypoint.EndPoint)
                    {
                        _attackSpeedDelta += Time.deltaTime;

                        if (_attackSpeed < _attackSpeedDelta)
                        {
                            _attackSpeedDelta = 0f;
                            Attack();
                        }
                    }
                    else
                    {
                        waypoint = waypoint.GetNextWaypoint;
                    }
                }
                else
                {
                    Move();
                }
            }
        }

        public void Damage(int damage)
        {
            _HP -= damage;
            _healthBar.UpdateSlider(_HP);

            if (_HP <= 0)
            {
                Death();
            }
        }

        protected virtual void Death()
        {
            waypoint = null;
            GameManager.instance.ennemyList.Remove(this);
        }

        protected virtual void Move()
        {
            var step = _speed * Time.deltaTime;
            Vector3 moveTowards = Vector3.MoveTowards(transform.position, waypoint.transform.position, step);
            _FlipSpriteFromVelocity(transform.position, moveTowards);
            transform.position = moveTowards;
        }

        protected virtual void Attack()
        {
            waypoint.GetComponent<Castle>().Damage(_damage);
        }

        // Called by the animation system.
        private void _AnimationDeath()
        {
            _poolEnnemy.PutBack(this);
        }

        private void _FlipSpriteFromVelocity(Vector3 currentPosition, Vector3 nextPosition)
        {
            _spriteRenderer.flipX = currentPosition.x > nextPosition.x;
        }
    }
}
