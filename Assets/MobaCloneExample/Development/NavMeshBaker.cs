using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _surface;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _surface.BuildNavMesh();
            Debug.Log("BuildNavMesh");
        }
    }
}