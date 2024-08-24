using System.Collections;
using UnityEngine;

public class FireWeapon : Weapons
{
    [Header("FireWeaponConfig")]
    [SerializeField]private int _fireRatePerS = 1;
    [SerializeField]private GameObject _bullet;
    private float _interval;
    protected override void Start()
    {
        base.Start();
        _interval = 1/_fireRatePerS;
        StartCoroutine(Attack() );
        Debug.Log("Here");
    }
    private void Fire()
    {
        GameObject bulletInstance = Instantiate(_bullet, gameObject.transform.position/*add offset here*/,gameObject.transform.rotation);
    }
    protected IEnumerator Attack()
    {
        while(true)
        {
            if(_closestPoint != null)
            {
                Fire();//make this calculation in the start
            }
            yield return new WaitForSeconds(_interval);
        }
    }
}
