using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionalMovableController : Controller
{
    private IDirectionalMovable _movable;

    public PlayerDirectionalMovableController(IDirectionalMovable movable)
    {
        _movable = movable;
    } 

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
        
        _movable.SetMoveDirection(inputDirection); 
    }
}
