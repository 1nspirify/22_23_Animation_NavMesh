using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMover 
{
    private NavMeshAgent _agent;
    
    public Vector3 CurrentVelocity => _agent.desiredVelocity;
    
    public AgentMover(NavMeshAgent agent, float movementSpeed)
    {
        _agent = agent;
        _agent.speed = movementSpeed;
        _agent.acceleration = 999f;

    }

    public void SetDestination(Vector3 target)
    {
        _agent.SetDestination(target);
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }
    
    public void Resume()
    {
        _agent.isStopped = false;
    }
    
}
