using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeTask
{
    public class AgentCharacterAnimation : MonoBehaviour
    {
        private readonly int _runningKey = Animator.StringToHash("IsRunning");

        [SerializeField] private Animator _animator;
        [SerializeField] private AgentCharacter _character;
        private int _normalizer = 100;


        void Update()
        {
            
            float _injuryAnimationLayer = Mathf.Clamp01(1f - (_character.Health / 100f));
            _animator.SetLayerWeight(1, 1 - _injuryAnimationLayer);

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

        public void Die()
        {
            _animator.CrossFade("Wasted", 0.2f, 0);
        }
    }
}