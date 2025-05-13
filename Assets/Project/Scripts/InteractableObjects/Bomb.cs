using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeTask
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _minDamagePoint = 5;
        [SerializeField] private int _maxDamagePoint = 15;

        [SerializeField] private float _explodeRadius = 4f;
        [SerializeField] private ParticleSystem _explodeParticles;
        
        private int Damage() => Random.Range(_minDamagePoint, _maxDamagePoint);
        
        public void Explode()
        {
            Instantiate(_explodeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
            Gizmos.DrawSphere(transform.position, _explodeRadius);
        }

        private void Update()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _explodeRadius);

            foreach (Collider collider in colliders)
                
                if (collider.GetComponent<AgentCharacter>() != null)
                {
                    AgentCharacter player = collider.GetComponent<AgentCharacter>();
                    player.TakeDamage(Damage());
                    Debug.Log("Pooph");
                    Explode();
                    
                    break;
                }
        }
    }
}