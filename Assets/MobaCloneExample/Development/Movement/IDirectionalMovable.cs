using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalMovable
{
    Vector3 CurrentVelocity { get; }

     void SetMoveDirection(Vector3 inputDirection);
}