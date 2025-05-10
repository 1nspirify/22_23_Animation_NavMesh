using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
{
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentDirection;
    
    public Vector3 Position => transform.position; 
   
    void Awake()
    {
        _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    void Update()
    {
        _mover.Update(Time.deltaTime);
        _rotator .Update(Time.deltaTime);
    }
    
    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);
    public void SetRotateDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
  
}
