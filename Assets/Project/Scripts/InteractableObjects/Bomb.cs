using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeTask
{
    public class Bomb : MonoBehaviour
    {
        private int _minDamagePoint = 5;
        private int _maxDamagePoint = 15;
        [SerializeField] private ParticleSystem _explodeParticles;

        public Bomb(int minDamagePoint, int maxDamagePoint)
        {
            _minDamagePoint = minDamagePoint;
            _maxDamagePoint = maxDamagePoint;
        }

        private int Damage() => Random.Range(_minDamagePoint, _maxDamagePoint);

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<AgentCharacter>() != null)
            {
                AgentCharacter player  = other.GetComponent<AgentCharacter>();
                player.TakeDamage(Damage());
                Explode();
            }
        }
        
        public void Explode()
        {
            Instantiate(_explodeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}