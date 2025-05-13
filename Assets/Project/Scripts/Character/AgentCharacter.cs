using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace HomeTask
{
    public class AgentCharacter : MonoBehaviour, IDamagable
    {
        private NavMeshAgent _agent;

        private CharacterHealth _health;
        private AgentMover _mover;
        private DirectionalRotator _rotator;

        [SerializeField] AgentCharacterAnimation _animation;
        
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _moveSpeed;

        // [SerializeField] private Transform _target;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;

        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        
        public int Health => _health.Points;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;

            _health = new CharacterHealth();
            _mover = new AgentMover(_agent, _moveSpeed);
            _rotator = new DirectionalRotator(transform, _rotationSpeed);
        }

        private void Update()
        {
            Debug.Log($"Current Health {_health.Points}");
            _rotator.Update(Time.deltaTime);
        }

        public void SetDestination(Vector3 position) => _mover.SetDestination(position);
        public void StopMove() => _mover.Stop();
        public void ResumeMove() => _mover.Resume();
        public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

        public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget) =>
            NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

        public void TakeDamage(int damage)
        {
            Debug.Log($"Damage {damage} has been taken");

            _health.Get(damage);

            if (_health.IsWasted)
            {
                _animation.Die();
            }
        }
    }

    public class CharacterHealth
    {
        private const int _maxHealth = 100;
        private const int _minHealth = 0;
        private int points = _maxHealth;

        public int Points => points;

        public bool IsWasted => points <= _minHealth;

        public void Get(int amount)
        {
            points -= Mathf.Abs(amount);
            
            if (points <= 0)
                points = _minHealth;
        }
    }
}