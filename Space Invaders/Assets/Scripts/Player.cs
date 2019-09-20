using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalLimit;
    [SerializeField] private float _firingCooldown;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _explosePrefab;
    
    private Rigidbody2D _rigidbody;
    private float _cooldownTimer;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Shot();
    }

    private void Shot()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= 0 && Input.GetAxis("Fire1") == 1)
        {
            _cooldownTimer = _firingCooldown;
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
       
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, 0);

        if (transform.position.x > _horizontalLimit)
        {
            transform.position = new Vector2(_horizontalLimit, transform.position.y);
            _rigidbody.velocity = Vector2.zero;
        }
        
        if (transform.position.x < -_horizontalLimit)
        {
            transform.position = new Vector2(-_horizontalLimit, transform.position.y);
            _rigidbody.velocity = Vector2.zero;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(_explosePrefab, transform.position, Quaternion.identity);
            Destroy(other.transform.gameObject);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
    }
}
