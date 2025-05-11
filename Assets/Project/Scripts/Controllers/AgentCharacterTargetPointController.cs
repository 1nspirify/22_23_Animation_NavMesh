using System.Collections;
using System.Collections.Generic;
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

        public AgentCharacterTargetPointController(AgentCharacter agentCharacter, InputService inputService ,
            float minDistanceToTarget, float timeForIdle)
        {
            
            _agentCharacter = agentCharacter;
            _minDistanceToTarget = minDistanceToTarget;
            _timeForIdle = timeForIdle;
            _inputService = inputService;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _idleTimer -= Time.deltaTime;

            Vector3 target = _inputService.Target;
      
            _agentCharacter.SetRotationDirection(_agentCharacter.CurrentVelocity);
     
            if (_agentCharacter.TryGetPath(target, _pathToTarget))
            {
              
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

        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
        private bool IdleTimerIsUp() => _idleTimer <= 0;
    }
}