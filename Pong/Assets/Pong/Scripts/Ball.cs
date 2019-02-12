using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _difficult = 1.1f;

    [SerializeField]
    private float _speedMinX = 1.5f;
    [SerializeField]
    private float _speedMaxX = 2.0f;
    [SerializeField]
    private float _speedMinY = 1.5f;
    [SerializeField]
    private float _speedMaxY = 2.0f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(Random.Range(_speedMinX,_speedMaxX) * (Random.value>0.5f ? -1 : 1),
                                   Random.Range(_speedMinY,_speedMaxY) * (Random.value>0.5f ? -1 : 1));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Bound")
        {
            GetComponent<AudioSource>().Play();
            //Ограничение сверху
            if (col.transform.position.y> transform.position.y && _rb.velocity.y > 0)
                _rb.velocity = new Vector2(_rb.velocity.x,-_rb.velocity.y);

            //Ограние снизу
            if (col.transform.position.y < transform.position.y && _rb.velocity.y < 0)
                _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
            
        }

        else if (col.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();
            //Ограничение слева
            if(col.transform.position.x < transform.position.x && _rb.velocity.x < 0)
                _rb.velocity = new Vector2(-_rb.velocity.x * _difficult, _rb.velocity.y * _difficult);

            //Ограничение справа
            if (col.transform.position.x > transform.position.x && _rb.velocity.x > 0)
                _rb.velocity = new Vector2(-_rb.velocity.x * _difficult, _rb.velocity.y * _difficult);
        }
    }
}
