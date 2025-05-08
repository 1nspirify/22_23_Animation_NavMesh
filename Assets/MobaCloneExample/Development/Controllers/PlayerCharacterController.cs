using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : Controller
{
    private Character _character;


    public PlayerCharacterController(Character character)
    {
        _character = character;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
        
        _character.SetMoveDirection(inputDirection);
        _character.SetRotateDirection(inputDirection);
    }
}
