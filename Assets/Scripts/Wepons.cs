using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepons : MonoBehaviour
{
    [Header("Attached to who?")]
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _radius;
    private Transform _closestEnemy;

    public void SetClosestEnemy(Transform closestEnemy)
    {
        _closestEnemy = closestEnemy;
    }
}
