using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Character _enemy;
    [SerializeField] private AgentCharacter _agentCharacter;

    private Controller _characterController;
    private Controller _enemyController;
    private Controller _agentEnemyController;
    
    private void Awake()
    {
        _characterController = new CompositeController(
            new PlayerDirectionalMovableController(_character),
            new AlongMovableVelocityRotatableController(_character, _character));

        _characterController.Enable();

        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = NavMesh.AllAreas;

        _enemyController =
            new CompositeController(  
                new DirectionalMovableAgroController(_enemy, _character.transform, 30, 2, queryFilter, 1),
                new AlongMovableVelocityRotatableController(_enemy, _enemy));
        
        _enemyController.Enable();
        
        _agentEnemyController = new AgentCharacterAgroController( _agentCharacter, _character.transform, 30,2,1);
        
        _agentEnemyController.Enable();
    } 

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
        
        _enemyController.Update(Time.deltaTime);
        
        _agentEnemyController.Update(Time.deltaTime); 
    }

    private void Start()
    {
        _enemy.gameObject.SetActive(false);
    }

    // private void OnDrawGizmosSelected()
    // {
    //     NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
    //     queryFilter.agentTypeID = 0;
    //     queryFilter.areaMask = NavMesh.AllAreas;
    //
    //     NavMesh.CalculatePath(_enemy.transform.position, _character.transform.position, queryFilter, _navMeshPath);
    //
    //     Gizmos.color = Color.red;
    //
    //     if (_navMeshPath.status != NavMeshPathStatus.PathInvalid)
    //     {
    //         foreach (Vector3 corner in _navMeshPath.corners)
    //         {
    //             Gizmos.DrawSphere(corner, 0.3f);
    //         }
    //     }
    // }
}