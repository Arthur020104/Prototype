using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    //[Header("Detection")]
    [SerializeField]private float _maxDistance = 10f, _speed = 4f,_offset = 1.5f;
    [SerializeField]private int _damage = 0;
    private Vector2 _inicialPos;
    private string _hitTag = "";
    void Start()
    {
        _inicialPos = gameObject.transform.position;
        gameObject.transform.Translate(Vector2.right * _offset);
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
    public void SetHitTag(string tag)
    {
        _hitTag = tag;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeSystem lf;
        Debug.Log("on bullet collision");
        if(other.gameObject.tag != _hitTag || !other.gameObject.TryGetComponent<LifeSystem>(out lf))
        {
            Debug.Log("Bullet hit something that does not have a LifeSystem component");
            return;
        }
        lf.TakeDamage(_damage);
        Destroy(gameObject);
    }
}