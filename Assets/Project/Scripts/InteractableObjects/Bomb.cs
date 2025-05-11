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
        
        public Bomb(int minDamagePoint, int maxDamagePoint)
        {
            _minDamagePoint = minDamagePoint;
            _maxDamagePoint = maxDamagePoint;
        }
        
        public int Damage => Random.Range(_minDamagePoint, _maxDamagePoint);

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}