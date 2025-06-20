using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
{
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _cameraTarget;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 Position => transform.position;
    
    public Transform CameraTarget => _cameraTarget;

    void Awake()
    {
        if (TryGetComponent(out CharacterController characterController))
        {
            _mover = new CharacterControllerDirectionalMover(characterController, _movementSpeed);
            _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        }

        else if (TryGetComponent(out Rigidbody rigidbody))
        {
            _mover = new RigidbodyDirectionalMover(rigidbody, _movementSpeed);
            _rotator = new RigidbodyDirectionalRotator(rigidbody, _rotationSpeed);
        }

        else
        {
            Debug.LogError("Mover component not found");
        }
    }

    void Update()
    {
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);
    public void SetRotateDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
}