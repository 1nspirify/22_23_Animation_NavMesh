using UnityEngine;
using UnityEngine.AI;

namespace HomeTask
{
    public class AgentCharacterTargetPointController : Controller
    {
        private AgentCharacter _agentCharacter;
        private InputService _inputService;

        private float _minDistanceToTarget;

        private float _idleTimer;
        private float _timeForIdle;

        private NavMeshPath _pathToTarget = new NavMeshPath();

        public AgentCharacterTargetPointController(AgentCharacter agentCharacter, InputService inputService,
            float minDistanceToTarget, float timeForIdle)
        {
            _agentCharacter = agentCharacter;
            _minDistanceToTarget = minDistanceToTarget;
            _timeForIdle = timeForIdle;
            _inputService = inputService;
            _idleTimer = _timeForIdle;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _idleTimer -= Time.deltaTime;

            if (_agentCharacter.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
            {
                
                if (_agentCharacter.InJumpProcess == false)
                {
                    _agentCharacter.SetRotationDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);
                    _agentCharacter.Jump(offMeshLinkData);
                }
                  
                return;
            }

            Vector3 target = _inputService.Target;

            _agentCharacter.SetRotationDirection(_agentCharacter.CurrentVelocity);

            if (_agentCharacter.TryGetPath(target, _pathToTarget))
            {
                
                if (target == Vector3.zero)
                {
                    _agentCharacter.StopMove();
                    return;
                }
                
                float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

                if (IsTargetReached(distanceToTarget))
                {
                    _idleTimer = _timeForIdle;
                }

                if (IdleTimerIsUp())
                {
                    _agentCharacter.ResumeMove();
                    _agentCharacter.SetDestination(target);
                    return;
                }
            }

            _agentCharacter.StopMove();
        }

        bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
        bool IdleTimerIsUp() => _idleTimer <= 0;
    }
}

