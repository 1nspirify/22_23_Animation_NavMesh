using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    private Controller _controller;
    
    
    public Character Spawn()
    {
        Character instance = Instantiate(_characterPrefab,_spawnPoint.position, Quaternion.identity);

        _followCamera.Follow = instance.CameraTarget;

        _controller = new CompositeController(
            new PlayerDirectionalMovableController(instance),
            new AlongMovableVelocityRotatableController(instance, instance));

        _controller.Enable();
        return instance;
    }

    private void Update()
    {
        _controller?.Update(Time.deltaTime );
    }
    
}