using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalRotatable
{
    Quaternion CurrentRotation { get; }

    void SetRotateDirection(Vector3 inputDirection);
}