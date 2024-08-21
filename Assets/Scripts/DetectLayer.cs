using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLayer : MonoBehaviour
{
    [SerializeField]private float _radiusDetection = 4;
    [SerializeField]private LayerMask _detectionLayer;
    [Header("Check Closest Enemy(60 update 1 time per seccond, 1 Update 60 times per seccond)")]
    [SerializeField]private int _frameUpdate = 0;
    private int frameUpdateCounter = 0, framesNumber = 0;
    public Transform closest = null;
    void Start()
    {
        if(_frameUpdate<=0)
        {
            _frameUpdate = 1;
        }
        framesNumber = 60/_frameUpdate;
    }
    void FixedUpdate()
    {
        FindEnemy();
    }
    static float Distance(Vector2 point1, Vector2 point2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(point1.x - point2.x, 2) + Mathf.Pow(point1.y - point2.y ,2));
        return distance;
    }
    void FindEnemy()
    {
        if(frameUpdateCounter > framesNumber)
        {
            Collider2D[] detectedColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, _radiusDetection,  _detectionLayer);
            foreach(Collider2D collider in detectedColliders)
            {
                if(closest == null || Distance(gameObject.transform.position, closest.position) > Distance(collider.gameObject.transform.position, gameObject.transform.position) )
                {
                    closest = collider.transform;
                }
            }
            framesNumber = 0;
        }
        frameUpdateCounter++;
    }
    public int GetFramesNumber()
    {
        return framesNumber;
    }
}
