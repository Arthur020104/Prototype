using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField]private int _lifeQuantity = 100;
    void Start()
    {
        if(_lifeQuantity<=0)
        {
            Debug.LogError("ERROR: GameObjectName: "+gameObject.name + " Life has to bigger than 0");

            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        _lifeQuantity -= damage;
        if(_lifeQuantity<=0)
        {
            Debug.Log("Destroying because player lifes is < 0"+ gameObject.name);
            Destroy(gameObject);
        }
    }

}
