 using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private AgentCharacter _agentCharacter;

    private Controller _characterController;

    private Controller _agentEnemyController;

    private void Awake()
    {
   

        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = 1;

        _agentEnemyController = new AgentCharacterAgroController(_agentCharacter, _character.transform, 30, 2, 1);

        _agentEnemyController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);

        _agentEnemyController.Update(Time.deltaTime);
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