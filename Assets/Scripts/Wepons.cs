using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepons : MonoBehaviour
{
    [Header("Attached to who?")]
    [SerializeField] private GameObject _pivot;
    private DetectLayer _playerDetectWhereToPoint;
    //this will be defined by the coldre class
    private float _radius = 1.3f;//radius from the pivit
    private Transform _closestEnemy;
    private float _timeToUpdateInS;
    [SerializeField]private float _offset = 180;
    private Vector3 _noEnemysPosition;
    //[Header("Gun things?")]
   // [SerializeField]private GameObject _gunPrefab;
    void Start()
    {
        if(!_pivot.TryGetComponent<DetectLayer>(out _playerDetectWhereToPoint))
        {
            Debug.LogError("Could not get the detectlayer component");
        }
        _timeToUpdateInS = _playerDetectWhereToPoint.GetTimeToUpdate();
        _noEnemysPosition = new Vector3(1,1,0);
        StartCoroutine("UpdatedWhereToPointCoroutine");
    }
    void Update()
    {
        UpdatedWhereToPoint();
    }
    void UpdatedWhereToPoint()
    {
        _closestEnemy = _playerDetectWhereToPoint.closest;
        if(_playerDetectWhereToPoint.closest != null )//&&_closestEnemy !=  _playerDetectWhereToPoint.closest)
        {
            UpdatePos(_closestEnemy.transform.position);
        }
        else
        {
            Debug.Log(_noEnemysPosition);
            gameObject.transform.position = _pivot.transform.position + _noEnemysPosition;
        }
    }
    void UpdatePos(Vector3 whereToUpdate)
    {
        Vector3 diff = whereToUpdate -_pivot.transform.position;
        diff /= Mathf.Sqrt(Mathf.Pow(diff.x,2)+Mathf.Pow(diff.y,2));
        diff *= _radius;

        gameObject.transform.position = _pivot.transform.position + diff;

        float angle = Mathf.Atan2( whereToUpdate.y - gameObject.transform.position.y,  whereToUpdate.x - gameObject.transform.position.x);
        angle+= _offset* Mathf.Deg2Rad;

        gameObject.transform.position = new Vector3(_pivot.transform.position.x + _radius * Mathf.Cos(angle),_pivot.transform.position.y + _radius * Mathf.Sin(angle),gameObject.transform.position.z);


        _noEnemysPosition = gameObject.transform.position - _pivot.transform.position;
    }
    IEnumerator UpdatedWhereToPointCoroutine()
    {
        while(true)
        {
            UpdatedWhereToPoint();
            yield return new WaitForSeconds(_timeToUpdateInS);
        }
    }
}
