using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionalRotatableController : Controller
{
    private IDirectionalRotatable _rotatable;

    public PlayerDirectionalRotatableController(IDirectionalRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
        
        _rotatable .SetRotateDirection(inputDirection);
    }
}
