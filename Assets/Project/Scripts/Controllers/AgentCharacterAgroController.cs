using UnityEngine;
using UnityEngine.AI;

namespace HomeTask
{
    public class AgentCharacterAgroController : Controller
    {
        private AgentCharacter _agentCharacter;
        private Transform _target;


        private float _agroRange;
        private float _minDistanceToTarget;

        private float _idleTimer;
        private float _timeForIdle;

        private NavMeshPath _pathToTarget = new NavMeshPath();

        public AgentCharacterAgroController(AgentCharacter agentCharacter, float agroRange,
            float minDistanceToTarget, float timeForIdle)
        {
            _agentCharacter = agentCharacter;
            _agroRange = agroRange;
            _minDistanceToTarget = minDistanceToTarget;
            _timeForIdle = timeForIdle;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _idleTimer -= Time.deltaTime;

            _agentCharacter.SetRotationDirection(_agentCharacter.CurrentVelocity);

            if (_agentCharacter.TryGetPath(_target.position, _pathToTarget))
            {
                float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

                if (IsTargetReached(distanceToTarget))
                {
                    _idleTimer = _timeForIdle;
                }

                if (InAgroRange(distanceToTarget) && IdleTimerIsUp())
                {
                    _agentCharacter.ResumeMove();
                    _agentCharacter.SetDestination(_target.position);
                    return;
                }

                _agentCharacter.StopMove();
            }
        }


        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
        private bool InAgroRange(float distanceToTarget) => distanceToTarget <= _agroRange;
        private bool IdleTimerIsUp() => _idleTimer <= 0;
    }
}