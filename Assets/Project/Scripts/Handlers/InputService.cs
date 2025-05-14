using UnityEngine;

namespace HomeTask
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AgentCharacter _agentCharacter;

        public Vector3 Target => _lastTarget;
        private Vector3 _lastTarget;

        private void Update()
        {
            if (_agentCharacter.IsAlive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    
                    if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
                    {
                        _lastTarget = hit.point;
                        Instantiate(_particleSystem, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}