using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLayer : MonoBehaviour
{
    [SerializeField]private float _radiusDetection = 4;
    [SerializeField]private LayerMask _detectionLayer;
    void FixedUpdate()
    {
        Collider2D[] detectedColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, _radiusDetection,  _detectionLayer);
        Transform closest = null;
        foreach(Collider2D collider in detectedColliders)
        {
            if(closest == null || Distance(gameObject.transform.position, closest.position) > Distance(collider.gameObject.transform.position, gameObject.transform.position) )
                closest = collider.transform;
        }
    }
    static float Distance(Vector2 point1, Vector2 point2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(point1.x - point2.x, 2) + Mathf.Pow(point1.y - point2.y ,2));
        return distance;
    }
}
