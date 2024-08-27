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
        if(_fireRatePerS <= 0)
        {
            Debug.LogError("FireRatePerS must be greater than 0");
            return;
        }
        _interval = 1/_fireRatePerS;
        StartCoroutine(Attack() );
        Debug.Log("Here");
    }
    private void Fire()
    {
        GameObject bulletInstance = Instantiate(_bullet, gameObject.transform.position/*add offset here*/,gameObject.transform.rotation);
        Bullet bullet;
        if(!bulletInstance.TryGetComponent<Bullet>(out bullet))
        {
            Debug.LogError("Could not get the bullet component");
            return;
        }
        bullet.SetHitTag(_hitTag);
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
