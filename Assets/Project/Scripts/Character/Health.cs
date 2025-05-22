using UnityEngine;

namespace HomeTask
{
    public class Health
    {
        private const int _maxHealth = 100;
        private const int _minHealth = 0;
        private int currentPoints = _maxHealth;

        private bool _isOver;
        public int CurrentPoints => currentPoints;
        public bool IsOver => currentPoints <= _minHealth;

        public void TakeDamage(int amount)
        {
            currentPoints -= Mathf.Abs(amount);

            if (currentPoints <= 0)
            {
                currentPoints = _minHealth;
            }
        }
    }
}