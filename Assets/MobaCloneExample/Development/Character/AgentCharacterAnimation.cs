using UnityEngine;

public class AgentCharacterAnimation : MonoBehaviour
{
    private readonly int _runningKey = Animator.StringToHash("IsRunning");
    private readonly int _jumpProcessKey = Animator.StringToHash("IsJumpProcess");
    
    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;
    
    void Update()
    {
        if (_character.CurrentVelocity.magnitude > 0.05f)
        {
            StartRunning();
        }
        
        else
        {
            StopRunning();
        }
    }

    private void StopRunning()
    {
        _animator.SetBool(_runningKey, true);
    }

    private void StartRunning()
    {
        _animator.SetBool(_runningKey, false);
    }
}
