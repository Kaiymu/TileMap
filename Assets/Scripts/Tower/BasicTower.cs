using Gameplay.Ennemies;
using PoolSystem.Runtime;
using UnityEngine;

namespace Gameplay.Tower
{
    public abstract class BasicTower : MonoBehaviour
    {
        [SerializeField]
        protected int _range = 3;
        [SerializeField]
        protected int _damage = 1;
        [SerializeField]
        protected float _shootingSpeed = 1f;

        protected PoolManager _poolArrow;

        protected Animator _animator;

        private float _shootingSpeedDelta = 0f;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _shootingSpeedDelta = _shootingSpeed;
        }

        private void Start()
        {
            _poolArrow = PoolManager.instance;
        }

        private void Update()
        {
            if (transform.parent == null)
                return; 

            _CalculateDistanceEnnemy();
        }

        private void _CalculateDistanceEnnemy()
        {
            Ennemy ennemy = null;
            float shortestDistance = float.MaxValue;

            for (int i = 0; i < GameManager.instance.GetActiveEnnemies().Count; i++)
            {
                var ennemies = GameManager.instance.GetActiveEnnemies()[i];

                var distanceEnnemy = Vector3.Distance(transform.position, ennemies.transform.position);

                if(distanceEnnemy < shortestDistance)
                {
                    shortestDistance = distanceEnnemy;
                    ennemy = ennemies;
                }
            }

            _shootingSpeedDelta += Time.deltaTime;

            if (shortestDistance < _range)
            {
                if (_shootingSpeed < _shootingSpeedDelta)
                {
                    _shootingSpeedDelta = 0f;
                    ShootAt(ennemy);

                    _FlipSpriteFromAim(transform.position, ennemy.transform.position);
                }
            }
            else
            {
                IsIdle();
            }

            if (ennemy == null)
            {
                IsIdle();
                return;
            }
        }

        public virtual void LevelUp()
        {
            _range += 1;
            _damage += 2;
            _shootingSpeed *= 0.5f;
        }

        protected abstract void IsIdle();

        protected abstract void ShootAt(Ennemy ennemy);

        private void _FlipSpriteFromAim(Vector3 currentPosition, Vector3 targetPosition)
        {
            _spriteRenderer.flipX = currentPosition.x > targetPosition.x;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}