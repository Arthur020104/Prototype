using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepons : MonoBehaviour
{
    [Header("Attached to who?")]
    [SerializeField] private GameObject _pivot;
    private DetectLayer _playerDetectWhereToPoint;
    [SerializeField] private float _radius;
    private Transform _closestEnemy;
    private int frameUpdateCounter = 0, framesNumber = 0;
    void Start()
    {
        if(!TryGetComponent<DetectLayer>(out _playerDetectWhereToPoint))
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
            _closestEnemy = _playerDetectWhereToPoint.closest;
            frameUpdateCounter = 0;
        }
        frameUpdateCounter++;
    }
}
