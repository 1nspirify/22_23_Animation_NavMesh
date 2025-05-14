using UnityEngine;

namespace HomeTask
{
    public class InputExample : MonoBehaviour
    {
        [SerializeField] private AgentCharacter _agentCharacter;
        [SerializeField] private InputService _inputService;
        
        private Controller _targetPointController;
        
        private void Awake()
        {
            _targetPointController =
                new AgentCharacterTargetPointController(_agentCharacter, _inputService, 2, 0);
            _targetPointController.Enable();
        }
        
        private void Update()
        {
            _targetPointController.Update(Time.deltaTime);
        }
    }
}