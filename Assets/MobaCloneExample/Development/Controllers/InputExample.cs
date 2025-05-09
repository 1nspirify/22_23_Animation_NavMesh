using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Tower _tower;

    private Controller _characterController;
    private Controller _towerController;

    private void Awake()
    {
        _characterController = new CompositeController(
            new PlayerDirectionalMovableController(_character),
            new PlayerDirectionalRotatableController(_character));

        _characterController.Enable();

        _towerController = new PlayerDirectionalRotatableController(_tower);
        _towerController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
        _towerController.Update(Time.deltaTime);
    }
}