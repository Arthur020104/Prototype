using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLayer : MonoBehaviour
{
    [SerializeField]private float _radiusDetection = 4;
    [SerializeField]private LayerMask _detectionLayer;
    [Header("Time to update in s")]
    [SerializeField]private float _timeToUpdateInS = 0f;
    public Transform closest = null;
    void Start()
    {
        if(_timeToUpdateInS<=0.01)
        {
            _timeToUpdateInS = 0.01f;
        }
        StartCoroutine("FindEnemyCoroutine");
    }
    static float Distance(Vector2 point1, Vector2 point2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(point1.x - point2.x, 2) + Mathf.Pow(point1.y - point2.y ,2));
        return distance;
    }
    void FindEnemy()
    {
        Collider2D[] detectedColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, _radiusDetection,  _detectionLayer);
        foreach(Collider2D collider in detectedColliders)
        {
            if(closest == null || Distance(gameObject.transform.position, closest.position) > Distance(collider.gameObject.transform.position, gameObject.transform.position) )
            {
                closest = collider.transform;
            }
        }
        Debug.Log(detectedColliders.Length );
        if(detectedColliders.Length ==0)
        {
            closest = null;
        }
            
    }
    public float GetTimeToUpdate()
    {
        return _timeToUpdateInS;
    }
    IEnumerator FindEnemyCoroutine()
    {
        while(true)
        {
            FindEnemy();
            yield return new WaitForSeconds(_timeToUpdateInS);
        }
    }
}
