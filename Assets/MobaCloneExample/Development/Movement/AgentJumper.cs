using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumper
{
    private NavMeshAgent _agent;
    private float _speed;
    private MonoBehaviour _coroutineRunner;
    private Coroutine _jumpProcess;
    private Animator _animator;
    private AnimationCurve _yOffsetCurve ;

    public AgentJumper(NavMeshAgent agent, 
        float speed, 
        MonoBehaviour coroutineRunner,
        AnimationCurve yOffsetCurve)
    {
        _agent = agent;
        _speed = speed;
        _coroutineRunner = coroutineRunner;
        _yOffsetCurve = yOffsetCurve;
    }
    
    public bool InProcess => _jumpProcess != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if (_jumpProcess != null)
            return;
        
        _jumpProcess = _coroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData));
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPosition = offMeshLinkData.startPos;
        Vector3 endPosition = offMeshLinkData.endPos;

        float duration = Vector3.Distance(endPosition, startPosition) / _speed;

        float progress = 0f;

        while (progress < duration)
        {
            float yOffset = _yOffsetCurve.Evaluate(progress/duration);
            _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress / duration)+ Vector3.up * yOffset;
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpProcess = null;
    }
}