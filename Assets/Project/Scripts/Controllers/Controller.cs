using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeTask
{
    public abstract class Controller
    {
        private bool _isEnabled;

        public virtual void Enable() => _isEnabled = true;
        public virtual void Disable() => _isEnabled = false;

        public void Update(float deltaTime)
        {
            Debug.Log("Update");
            if (_isEnabled == false)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}