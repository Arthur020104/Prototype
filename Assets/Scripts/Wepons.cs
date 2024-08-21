using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepons : MonoBehaviour
{
    [Header("Attached to who?")]
    [SerializeField] private GameObject _pivot;
    private DetectLayer _playerDetectWhereToPoint;
    [Header("Radius to detect?")]
    [SerializeField] private float _radius;
    private Transform _closestEnemy;
    private int frameUpdateCounter = 0, framesNumber = 0;
    //[Header("Gun things?")]
   // [SerializeField]private GameObject _gunPrefab;
    void Start()
    {
        if(!_pivot.TryGetComponent<DetectLayer>(out _playerDetectWhereToPoint))
        {
            Debug.LogError("Could not get the detectlayer component");
        }
        framesNumber = _playerDetectWhereToPoint.GetFramesNumber();
    }
    void Update()
    {
        UpdatedWhereToPoint();
    }
    void UpdatedWhereToPoint()
    {
        if(frameUpdateCounter >= framesNumber)
        {
            if(_playerDetectWhereToPoint.closest !=null )//&&_closestEnemy !=  _playerDetectWhereToPoint.closest)
            {
                _closestEnemy = _playerDetectWhereToPoint.closest;
                Vector3 diff = _closestEnemy.position -_pivot.transform.position;
                diff /= Mathf.Sqrt(Mathf.Pow(diff.x,2)+Mathf.Pow(diff.y,2));
                diff *= _radius;
                Debug.Log(diff);
                Debug.Log( _pivot.transform.position +diff);
                gameObject.transform.position = _pivot.transform.position +diff;
            }
            
                
            
            frameUpdateCounter = 0;
        }
        frameUpdateCounter++;
    }
}
