using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeTask
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _minDamagePoint = 5;
        [SerializeField] private int _maxDamagePoint = 15;
        [SerializeField] private float _explodeRadius = 4f;

        [SerializeField] private BombView _bombView;
        
        private float _delayExplosion = 3f;
        private bool _isExploded;
        
        private int Damage() => Random.Range(_minDamagePoint, _maxDamagePoint);

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
            Gizmos.DrawSphere(transform.position, _explodeRadius);
        }

        private void Update()
        {
            if (_isExploded) return;

            Collider[] colliders = Physics.OverlapSphere(transform.position, _explodeRadius);

            foreach (Collider collider in colliders)

                if (collider.GetComponent<AgentCharacter>() != null)
                {
                    StartCoroutine(Explode());
                    Debug.LogWarning("Collider has been detected");

                    break;
                }
        }

        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(_delayExplosion);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _explodeRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<AgentCharacter>() != null)
                {
                    Debug.LogWarning("Explosion in 3 seconds");
                    AgentCharacter player = collider.GetComponent<AgentCharacter>();

                    player.TakeDamage(Damage());
                    _isExploded = true;
                }
            }

            _bombView.Explosion();
            Destroy(gameObject);
        }
    }
}