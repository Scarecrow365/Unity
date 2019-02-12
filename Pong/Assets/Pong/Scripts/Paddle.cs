using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int playerIndex = 1;

    private float _verticalMovement;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Controller();
    }

    //void Controller()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

    //        if (playerIndex == 2)
    //        {
    //            if (relativeMousePostion.x > 0.5f)
    //            {
    //                for (int i = 0; i < Input.touchCount; i++)
    //                {
    //                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
    //                    _rb.velocity = new Vector2(0,touchPosition.y);
    //                }
    //                //    if (relativeMousePostion.y < 0.5f)
    //                //        _rb.velocity = new Vector2(0, -_speed);
    //                //    if (relativeMousePostion.y > 0.5f)
    //                //        _rb.velocity = new Vector2(0, _speed);
    //            }
    //        }

    //        if (playerIndex == 1)
    //        {
    //            if (relativeMousePostion.x < 0.5f)
    //            {
    //                for (int i = 0; i < Input.touchCount; i++)
    //                {
    //                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
    //                    _rb.velocity = new Vector2(0, touchPosition.y);
    //                }
    //                //if (relativeMousePostion.y < 0.5f)
    //                //    _rb.velocity = new Vector2(0, -_speed);
    //                //if (relativeMousePostion.y > 0.5f)
    //                //    _rb.velocity = new Vector2(0, _speed);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        _rb.velocity = Vector2.zero;
    //    }
    //}
    //void Controller()
    //{
    //    //for (int i = 0; i < Input.touchCount; i++)
    //    //{
    //        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
    //        Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
    //        _rb.velocity = Vector2.zero;

    //        if (playerIndex == 1)
    //        {
    //            if (relativeMousePostion.x < 0.5f)
    //            {
    //                if (touchPosition.y > transform.position.y)
    //                    _rb.velocity = new Vector2(0, _speed);

    //                if (touchPosition.y < transform.position.y)
    //                    _rb.velocity = new Vector2(0, -_speed);
    //            }
    //        }


    //        if (playerIndex == 2)
    //        {
    //            if (relativeMousePostion.x > 0.5f)
    //            {
    //                if (touchPosition.y > transform.position.y)
    //                    _rb.velocity = new Vector2(0, _speed);

    //                if (touchPosition.y < transform.position.y)
    //                    _rb.velocity = new Vector2(0, -_speed);
    //            }
    //        }
    //    //}
    //}

    //void Controller()
    //{

    //    Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width, 
    //                                               Input.mousePosition.y / Screen.height);
    //    //Touch touch = Input.GetTouch(0);

    //    if (relativeMousePostion.x < 0.5f)
    //    {
    //        if (playerIndex == 1)
    //        {
    //            for (int i = 0; i < Input.touchCount; i++)
    //            //if(Input.touchCount > 0)
    //            {
    //                Vector2 touchPosition = Camera.main.WorldToScreenPoint(Input.touches[i].position);
    //                //Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

    //                if (touchPosition.y > transform.position.y)
    //                    _rb.velocity = new Vector2(0, _speed);
    //                if (touchPosition.y < transform.position.y)
    //                    _rb.velocity = new Vector2(0, -_speed);
    //                else
    //                    _rb.velocity = Vector2.zero;
    //                //_rb.velocity = new Vector2(0, touchPosition.y);
    //            }
    //        }
    //    }

    //    if (relativeMousePostion.x > 0.5f)
    //    {
    //        if (playerIndex == 2)
    //        {
    //            for (int i = 0; i < Input.touchCount; i++)
    //            {
    //                Vector2 touchPosition = Camera.main.WorldToScreenPoint(Input.touches[i].position);
    //                //Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

    //                if (touchPosition.y > transform.position.y)
    //                    _rb.velocity = new Vector2(0, _speed);
    //                if (touchPosition.y < transform.position.y)
    //                    _rb.velocity = new Vector2(0, -_speed);
    //                else
    //                    _rb.velocity = Vector2.zero;

    //            }
    //        }
    //    }
    //}
    //void Controller()
    //{
    //    Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width,
    //                                               Input.mousePosition.y / Screen.height);

    //    int touchAmount = 0;
    //    List<Vector2> touchCoordinates = new List<Vector2>();

    //    foreach (Touch touch in Input.touches)
    //    {
    //        touchAmount++;
    //        touchCoordinates.Add(touch.position);
    //    }

    //    if (playerIndex == 1)
    //    {
    //            if (relativeMousePostion.x < 0.5f)
    //            {
    //                touchAmount++;
    //                if (relativeMousePostion.y > transform.position.y)
    //                    _rb.velocity = new Vector2(0, _speed);
    //                if (relativeMousePostion.y < transform.position.y)
    //                    _rb.velocity = new Vector2(0, -_speed);

    //            }

    //            //for (int i = 0; i < Input.touchCount; i++)
    //            //{
    //            //    Vector2 touchPosition = Camera.main.WorldToScreenPoint(Input.touches[i].position);
    //            //    //Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

    //            //    if (relativeMousePostion.y > transform.position.y)
    //            //        _rb.velocity = new Vector2(0, _speed);
    //            //    if (relativeMousePostion.y < transform.position.y)
    //            //        _rb.velocity = new Vector2(0, -_speed);

    //            //}

    //    }
    //    else
    //        _rb.velocity = Vector2.zero;


    //    if (playerIndex == 2)
    //    {
    //        if (relativeMousePostion.x > 0.5f)
    //        {

    //            touchAmount++;
    //            if (relativeMousePostion.y > transform.position.y)
    //                _rb.velocity = new Vector2(0, _speed);
    //            if (relativeMousePostion.y < transform.position.y)
    //                _rb.velocity = new Vector2(0, -_speed);


    //            //for (int i = 0; i < Input.touchCount; i++)
    //            //{
    //            //    Vector2 touchPosition = Camera.main.WorldToScreenPoint(Input.touches[i].position);
    //            //    //Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //            //    Debug.Log(relativeMousePostion.y);

    //            //    if (relativeMousePostion.y > transform.position.y)
    //            //        _rb.velocity = new Vector2(0, _speed);
    //            //    if (relativeMousePostion.y < transform.position.y)
    //            //        _rb.velocity = new Vector2(0, -_speed);


    //            //}
    //        }
    //    }
    //    else
    //        _rb.velocity = Vector2.zero;
    //}

    //void Controller()
    //{

    //    for (int i = 0; i < Input.touchCount; i++)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
    //        Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width,
    //                                                   Input.mousePosition.y / Screen.height);

    //        if (playerIndex == 1 && relativeMousePostion.x < 0.5f)
    //        {
    //            if (touchPosition.y > transform.position.y)
    //                _rb.velocity = new Vector2(0, _speed);
    //            else if (touchPosition.y < transform.position.y)
    //                _rb.velocity = new Vector2(0, -_speed);
    //        }

    //        if (playerIndex == 2 && relativeMousePostion.x > 0.5f)
    //        {
    //            if (touchPosition.y > transform.position.y)
    //                _rb.velocity = new Vector2(0, _speed);
    //            if (touchPosition.y < transform.position.y)
    //                _rb.velocity = new Vector2(0, -_speed);
    //        }

    //        if (touch.phase == TouchPhase.Ended)
    //        {
    //            if (playerIndex == 1)
    //                _rb.velocity = Vector2.zero;
    //            if (playerIndex == 2)
    //                _rb.velocity = Vector2.zero;
    //        }
    //    }
    //}
    void Controller()
    {

        Vector2 relativeMousePostion = new Vector2(Input.mousePosition.x / Screen.width,
                                                   Input.mousePosition.y / Screen.height);
        //Touch touch = Input.GetTouch(0);



        for (int i = 0; i < Input.touchCount; i++)
            //if(Input.touchCount > 0)
        {
            //Vector2 touchPosition = Camera.main.WorldToScreenPoint(Input.touches[i].position);
            Vector2 touchPosition = new Vector2(Input.touches[i].position.x / Screen.width,
                                                Input.touches[i].position.y / Screen.height);
            //Debug.Log(touchPosition);
            //Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (relativeMousePostion.x < 0.5f)
            {
                if (playerIndex == 1)
                {
                    _rb.velocity = Vector2.zero;
                    if (touchPosition.y > transform.position.y)
                        _rb.velocity = new Vector2(0, _speed);
                    else if (touchPosition.y < transform.position.y)
                        _rb.velocity = new Vector2(0, -_speed);
                    //_rb.velocity = new Vector2(0, touchPosition.y);
                }
            }

            if (playerIndex == 2 && relativeMousePostion.x > 0.5f)
            {
                if (touchPosition.y > transform.position.y)
                    _rb.velocity = new Vector2(0, _speed);
                if (touchPosition.y < transform.position.y)
                    _rb.velocity = new Vector2(0, -_speed);
            }
        }
    }
}


