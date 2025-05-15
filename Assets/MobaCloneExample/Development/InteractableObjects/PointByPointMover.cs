using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PointByPointMover : MonoBehaviour
{
   [SerializeField] private List<Transform> _points;
   [SerializeField] private float  _timeBetweenMoves;
   [SerializeField] private float  _speed;
   
   private Queue<Vector3> _pointsPositions;
   private Vector3 _currentTarget;


   private void Awake()
   {
      _pointsPositions = new Queue<Vector3>();
      
      foreach (Transform point in _points)
         _pointsPositions.Enqueue(point.position);

      StartCoroutine(MoveProcess());
   }

   private IEnumerator MoveProcess()
   {
      while (true)
      {
         SwitchPoint();
         
         Vector3 startPosition = transform.position;
         Vector3 endPosition = _currentTarget;
         
         float timeForMovement = (endPosition - startPosition).magnitude / _speed;
         
         float progress = 0;

         while (progress < timeForMovement)
         {
            transform.position = Vector3.Lerp(startPosition, endPosition, progress/timeForMovement);
            progress += Time.deltaTime;
            yield return null;
         }
         
         yield return new WaitForSeconds(_timeBetweenMoves);
      } 
   }

   private void SwitchPoint()
   {
      _currentTarget = _pointsPositions.Dequeue();
      _pointsPositions.Enqueue(_currentTarget);
   }
}
