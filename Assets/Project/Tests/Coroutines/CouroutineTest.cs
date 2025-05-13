using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineTest : MonoBehaviour
{
  private List<int> _numbers = new List<int>();
  private void Awake()
  {
    throw new NotImplementedException();

    CouroutineProcess();
  }

  private IEnumerator CouroutineProcess()
  {
    Debug.Log("CouroutineProcess");
    yield return null; 
    Debug.Log("CouroutineProcess");
    yield return null; 
    Debug.Log("CouroutineProcess");
    yield return null; 
    Debug.Log("CouroutineProcess");
    yield return null;
  }
}
