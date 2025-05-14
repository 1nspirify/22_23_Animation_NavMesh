using UnityEngine;

namespace HomeTask
{
    public class AgentCharacterAnimation : MonoBehaviour
    {
        private readonly int _runningKey = Animator.StringToHash("IsRunning");

        [SerializeField] private Animator _animator;
        [SerializeField] private AgentCharacter _character;
        
        private int _percent = 100;
        private const string _death  = "Wasted";
        
        void Update()
        {
            InjuryLayerWeightCondition();
            
            if (_character.CurrentVelocity.magnitude > 0.05f)
            {
                StartRunning();
            }

            else
            {
                StopRunning();
            }
            
        }

        private void InjuryLayerWeightCondition()
        {
            float healthPercent = _character.Health / _percent;
            float injuryWeight = 1f - healthPercent;
            
            _animator.SetLayerWeight(1, injuryWeight);
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
            _animator.CrossFade(_death, 0.2f, 0);
        }
    }
}