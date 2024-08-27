using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coldre : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    [Header("Tag to hit")]
    [SerializeField]private string _hitTag = "";

    void Start()
    {
        Weapons[] weaponInstances = new Weapons[_weapons.Length];
        
        for (int i = 0; i < _weapons.Length; i++)
        {
            GameObject weaponObject = Instantiate(_weapons[i], transform.position, Quaternion.identity);
            weaponObject.transform.SetParent(gameObject.transform);
            weaponInstances[i] = weaponObject.GetComponent<Weapons>();
            weaponInstances[i].SetHitTag(_hitTag);
        }

        Weapons.CheckWeapons(weaponInstances);
    }
}
