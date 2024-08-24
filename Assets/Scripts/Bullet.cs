using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    //[Header("Detection")]

    [SerializeField]private string _hitTag;
    [SerializeField]private float _maxDistance = 10f, _speed = 4f;
    [SerializeField]private int _damage = 0;
    private Vector2 _inicialPos;
    void Start()
    {
        _inicialPos = gameObject.transform.position;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector2.right * _speed * Time.deltaTime);
        if(DetectLayer.Distance(_inicialPos, gameObject.transform.position) > _maxDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeSystem lf;
        Debug.Log("on bullet collision");
        if(other.gameObject.tag != _hitTag || !other.gameObject.TryGetComponent<LifeSystem>(out lf))
        {
            return;
        }
        lf.TakeDamage(_damage);
    }
}