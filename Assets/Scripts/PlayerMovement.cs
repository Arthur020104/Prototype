using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Things")]
    [SerializeField]private float _speed;

    [SerializeField]private int _movementMode = 0;

    private Rigidbody2D _myRb;
    
    void Start()
    {
        if(_speed == 0)
        {
            Debug.LogWarning("Player will not move, speed is set to 0");
        }
        if(!TryGetComponent<Rigidbody2D>(out _myRb))
        {
            Debug.LogError("Could not get Rb");
        }
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        switch (_movementMode)
        {
            case 1:
            _myRb.velocity = new Vector2(horizontalInput*_speed,verticalInput*_speed);
            break;
            case 2:
            gameObject.transform.Translate(( Vector3.up * Time.deltaTime * verticalInput * _speed) +( Vector3.right * Time.deltaTime * horizontalInput * _speed));
            break;
        }
    }
}
