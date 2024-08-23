using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("Attached to who?")]
    [SerializeField] private GameObject _pivot;

    private float _offset, _timeToUpdateInS;

    private DetectLayer _detectWhereToPoint;

    private Transform _closestPoint;

    private Vector3 _noEnemysPosition;


    public static float BASEOFFSET = 20;

    private static float RADIUS = 1.3f;

    public static void CheckWepons()
    {
        Weapons[] allWeapons = FindObjectsOfType<Weapons>();

        if (allWeapons.Length * BASEOFFSET > 360)
        {
            Debug.LogError("ERROR: Too many weapon objects in the scene.");
            return;
        }

        allWeapons[0]._offset = 0; // The first weapon does not have an offset

        for (int i = 1; i < allWeapons.Length; i += 2)
        {
            allWeapons[i]._offset = BASEOFFSET * (i + 1) / 2;

            if (i + 1 < allWeapons.Length)
                allWeapons[i + 1]._offset = -BASEOFFSET * (i + 1) / 2;
        }
    }

    void Start()
    {
        if(!_pivot.TryGetComponent<DetectLayer>(out _detectWhereToPoint))
        {
            Debug.LogError("Could not get the detectlayer component");
        }
        _timeToUpdateInS = _detectWhereToPoint.GetTimeToUpdate();
        _noEnemysPosition = new Vector3(1,1,0);
        StartCoroutine("UpdatedWhereToPointCoroutine");
    }
    void Update()
    {
        UpdatedWhereToPoint();
    }
    void UpdatedWhereToPoint()
    {
        _closestPoint = _detectWhereToPoint.GetClosest();
        if(_closestPoint != null )//&&_closestEnemy !=  _playerDetectWhereToPoint.closest)
        {
            UpdatePos(_closestPoint.transform.position);
            return;
        }
        gameObject.transform.position = _pivot.transform.position + _noEnemysPosition;
    }
    void UpdatePos(Vector3 whereToUpdate)//Refactor later
    {
        Vector3 diff = whereToUpdate -_pivot.transform.position;
        diff /= Mathf.Sqrt(Mathf.Pow(diff.x,2)+Mathf.Pow(diff.y,2));
        diff *= RADIUS;

        gameObject.transform.position = _pivot.transform.position + diff;

        float angle = Mathf.Atan2( whereToUpdate.y - gameObject.transform.position.y,  whereToUpdate.x - gameObject.transform.position.x);
        angle+= _offset* Mathf.Deg2Rad;

        gameObject.transform.position = new Vector3(_pivot.transform.position.x + RADIUS * Mathf.Cos(angle),_pivot.transform.position.y + RADIUS * Mathf.Sin(angle),gameObject.transform.position.z);
        
        //float whereToPoint = Mathf.Atan2(diff.y, diff.x);
        //gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, whereToPoint * Mathf.Rad2Deg));
        transform.right = whereToUpdate - transform.position;

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
