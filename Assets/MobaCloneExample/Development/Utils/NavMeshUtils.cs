using UnityEngine;
using UnityEngine.AI;

public class NavMeshUtils : MonoBehaviour
{
    public static float GetPathLength(NavMeshPath path)
    {
        float pathLenth = 0f;

        if (path.corners.Length > 0)
        {
            for (int i = 1; i < path.corners.Length; i++)
            {
                pathLenth += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }

        return pathLenth;
    }

    public static bool TryGetPath(Vector3 sourcePosition, Vector3 targetPosition, NavMeshQueryFilter queryFilter,
        NavMeshPath pathToTarget)
    {
        if (NavMesh.CalculatePath(sourcePosition, targetPosition, queryFilter, pathToTarget) &&
            pathToTarget.status != NavMeshPathStatus.PathInvalid)
        {
            return true;
        }

        return false;
    }
    public static bool TryGetPath(NavMeshAgent navMeshAgent, Vector3 targetPosition, 
        NavMeshPath pathToTarget)
    {
        if (navMeshAgent.CalculatePath(targetPosition, pathToTarget) &&
            pathToTarget.status != NavMeshPathStatus.PathInvalid)
        {
            return true;
        }

        return false;
    }
}