using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace HomeTask
{
    public class InputExample : MonoBehaviour
    {
        // [SerializeField] private Character _character;
        // [SerializeField] private Character _enemy;
        [SerializeField] private AgentCharacter _agentCharacter;
        [SerializeField] private InputService _inputService;


        // private Controller _characterController;
        // private Controller _enemyController;
        // private Controller _agentEnemyController;
        private Controller _targetPointController;


        private void Awake()
        {
            // _characterController = new CompositeController(
            //     new PlayerDirectionalMovableController(_character),
            //     new AlongMovableVelocityRotatableController(_character, _character));
            //
            // _characterController.Enable();
            //
            // NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
            // queryFilter.agentTypeID = 0;
            // queryFilter.areaMask = NavMesh.AllAreas;
            //
            // _enemyController =
            //     new CompositeController(
            //         new DirectionalMovableAgroController(_enemy, _character.transform, 30, 2, queryFilter, 1),
            //         new AlongMovableVelocityRotatableController(_enemy, _enemy));

            // _enemyController.Enable();

            // _agentEnemyController = new AgentCharacterAgroController(_agentCharacter, 30, 2, 1);
            // _agentEnemyController.Enable();

            _targetPointController =
                new AgentCharacterTargetPointController(_agentCharacter, _inputService, 2, 0);
            _targetPointController.Enable();
            Debug.Log("Agent character target point");
        }

        private void Update()
        {
            // _characterController.Update(Time.deltaTime);
            //
            // _enemyController.Update(Time.deltaTime);

            // _agentEnemyController.Update(Time.deltaTime);

            _targetPointController.Update(Time.deltaTime);
        }
    }
}