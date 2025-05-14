using UnityEngine;

namespace HomeTask
{
    public class Health
    {
        private const int _maxHealth = 100;
        private const int _minHealth = 0;
        private int currentPoints = _maxHealth;

        private bool _isAlive;
        public int CurrentPoints => currentPoints;
        public bool IsAlive => currentPoints > _minHealth;

        public void Get(int amount)
        {
            currentPoints -= Mathf.Abs(amount);

            if (currentPoints <= 0)
            {
                currentPoints = _minHealth;
            }
        }
    }
}