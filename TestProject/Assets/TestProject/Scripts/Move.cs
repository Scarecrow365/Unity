using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * _speed);
    }
}
