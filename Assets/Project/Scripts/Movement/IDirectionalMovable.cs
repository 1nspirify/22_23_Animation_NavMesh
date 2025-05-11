using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeTask
{
    public interface IDirectionalMovable : ITransformPosition
    {
        Vector3 CurrentVelocity { get; }

        void SetMoveDirection(Vector3 inputDirection);
    }
}