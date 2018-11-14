using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private int playerIndex = 1;

    private float _verticalMovement;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Controller();
        _verticalMovement = Input.GetAxis("Vertical" + playerIndex);
        _rb.velocity = new Vector2(0, _verticalMovement * _speed);
    }

    //void Controller()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

    //        if(relativeMousePostion.y < 0.5f)
    //            _rb.velocity = new Vector2(0,-_speed);
    //        if (relativeMousePostion.y > 0.5f)
    //            _rb.velocity = new Vector2(0, _speed);
    //    }
    //    else
    //    {
    //        _rb.velocity = Vector2.zero;
    //    }
    //}
}
