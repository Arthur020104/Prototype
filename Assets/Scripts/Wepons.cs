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
    void FixedUpdate()
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
                Vector3 diff = _pivot.transform.position - _closestEnemy.position;
                diff /= Mathf.Sqrt(Mathf.Pow(diff.x,2)+Mathf.Pow(diff.y,2));
                gameObject.transform.position = diff * _radius;
            }
            
                
            
            frameUpdateCounter = 0;
        }
        frameUpdateCounter++;
    }
}
