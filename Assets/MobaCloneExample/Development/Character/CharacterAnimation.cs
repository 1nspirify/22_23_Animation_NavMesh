using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private readonly int _runningKey = Animator.StringToHash("IsRunning");
    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    
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