using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private AgentCharacter _prefab;

    [SerializeField] private float _radius;

    [SerializeField] private int _count;

    private List<Controller> _controllers = new(); 

    public void Spawn(Transform target)
    {
        Vector3 positionAroundTarget;
        NavMeshHit spawnPoint;

        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = 1;

        for (int i = 0; i < _count; i++)
        {
            do
            {
                Vector2 randomPositionInCircle = Random.insideUnitCircle * _radius;
                Vector3 offset = new Vector3(randomPositionInCircle.x, 0, randomPositionInCircle.y);

                positionAroundTarget = target.position + offset;
            } while (NavMesh.SamplePosition(positionAroundTarget, out spawnPoint, 0.1f, queryFilter) == false);

            AgentCharacter instance = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);

            Controller controller = new AgentCharacterAgroController(instance, target, 30, 2, 1);

            controller.Enable();

            _controllers.Add(controller);
        }
    }

    private void Update()
    {
        foreach (Controller controller in _controllers)
        {
            controller.Update(Time.deltaTime);
        }
    }
}