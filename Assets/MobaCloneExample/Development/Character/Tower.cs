using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDirectionalRotatable 
{
    private DirectionalRotator _rotator;
    
    [SerializeField] private float _rotationSpeed;
    
    public Quaternion CurrentRotation => _rotator.CurrentDirection;
   
    void Awake()
    {
        _rotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    void Update()
    {
        _rotator .Update(Time.deltaTime);
    }
    
    public void SetRotateDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
}
