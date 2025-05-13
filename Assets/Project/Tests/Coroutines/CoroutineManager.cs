using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _entities;
    [SerializeField] private List<Coroutine> _rotateProcesses = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            foreach (Transform entity in _entities)
                _rotateProcesses.Add(StartCoroutine(ProcessRotateFor(entity)));

        if (Input.GetKeyDown(KeyCode.S))
            foreach (Coroutine rotateProcess in _rotateProcesses)
                if (rotateProcess != null)
                    StopCoroutine(rotateProcess);
        
        _rotateProcesses.Clear();
    }

    private IEnumerator ProcessRotateFor(Transform entity)
    {
        while (true)
        {
            entity.Rotate(Vector3.up * Time.deltaTime * 100, Space.World);
            yield return null;
        }
    }
}