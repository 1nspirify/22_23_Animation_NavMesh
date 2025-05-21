using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;


public class AgentCharacter : MonoBehaviour
{
    private NavMeshAgent _agent;

    private AgentMover _mover;
    private TransformDirectionalRotator _rotator;

    private AgentJumper _jumper;

    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AnimationCurve _jumperCurve;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public bool InJumpProcess => _jumper.InProcess;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        _jumper = new AgentJumper(_agent, _jumpSpeed, this, _jumperCurve);
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 position) => _agent.SetDestination(position);
    public void StopMove() => _mover.Stop();
    public void ResumeMove() => _mover.Resume();
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget) =>
        NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

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
}