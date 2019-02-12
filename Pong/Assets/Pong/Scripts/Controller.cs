using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float _speed;
    [SerializeField] private float _verticalSpeed;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Up()
    {
        _speed = _verticalSpeed;
    }

    public void Down()
    {
        _speed = -_verticalSpeed;
    }

    public void Stop()
    {
        _speed = 0;
    }

    void Update()
    {
        _rb.velocity = new Vector2(0,_speed);
    }
}
