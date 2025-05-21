using UnityEngine;
using UnityEngine.AI;

namespace HomeTask
{
    public class AgentCharacter : MonoBehaviour, IDamagable
    {
        private NavMeshAgent _agent;

        private Health _health;
        private AgentMover _mover;
        private AgentJumper _jumper;
        private DirectionalRotator _rotator;

        [SerializeField] AgentCharacterAnimation _animation;

        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private AnimationCurve _jumpCurve;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;

        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        public bool InJumpProcess => _jumper.InProcess;

        public int Health => _health.CurrentPoints;

        public bool IsAlive => _health.IsAlive;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;

            _health = new Health();

            _mover = new AgentMover(_agent, _moveSpeed);
            _rotator = new DirectionalRotator(transform, _rotationSpeed);
            _jumper = new AgentJumper(_agent, _jumpSpeed, this, _jumpCurve);
        }

        private void Update()
        {
            Debug.Log($"Current Health {_health.CurrentPoints}");
            _rotator.Update(Time.deltaTime);
        }

        public void SetDestination(Vector3 position) => _mover.SetDestination(position);
        public void StopMove() => _mover.Stop();
        public void ResumeMove() => _mover.Resume();
        public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
        
        public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
        {
            if (_agent.isOnOffMeshLink)
            {
                offMeshLinkData = _agent.currentOffMeshLinkData;
                return true;
            }

            offMeshLinkData = default(OffMeshLinkData);
            return false;
        }
        public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData); 

        public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget) =>
            NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

        public void TakeDamage(int damage)
        {
            Debug.Log($"Damage {damage} has been taken");

            _health.Get(damage);

            if (_health.IsAlive == false)
            {
                _animation.Die();
            }
        }
    }
}