using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _firingSpeed;
    [SerializeField] private float _destroyTime;

    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        if (gameObject.CompareTag("EnemyBullet"))
            _firingSpeed = -_firingSpeed;
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(0, _firingSpeed);
        Destroy(gameObject, _destroyTime);
    }
}
