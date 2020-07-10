using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedFactor;
    [SerializeField] private GameData _gameData;
    [SerializeField] private ParticleSystem _particleSystem;
    [Header("Max Speed")]
    [SerializeField] private float _speedMaxX;
    [SerializeField] private float _speedMaxY;
    [Header("Min Speed")]
    [SerializeField] private float _speedMinX;
    [SerializeField] private float _speedMinY;
    private const float Percent = 0.01f;
    private const float BorderY = 4.3f;
    private float _borderX;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _borderX = Screen.width * Percent;
    }

    private void Start()
    {
        CreateDirection();
    }

    private void Update()
    {
        CheckBorders();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Paddle")) return;
        _audioSource.Play();
        _rigidbody.velocity =
            new Vector2(
                (_rigidbody.velocity.x * -1) * _speedFactor, 
                _rigidbody.velocity.y * _speedFactor);
    }

    private void CreateDirection()
    {
        _rigidbody.velocity = new Vector2(
            Random.Range(_speedMinX, _speedMaxX) * (Random.value > 0.5f ? -1 : 1),
            Random.Range(_speedMinY, _speedMaxY) * (Random.value > 0.5f ? -1 : 1));
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        CreateDirection();
    }

    private void CheckBorders()
    {
        //Ограничение сверху
        if (BorderY < transform.position.y && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_rigidbody.velocity.y);
            _audioSource.Play();
            _particleSystem.gameObject.transform.position = transform.position;
            _particleSystem.Play();
        }

        //Ограничение снизу
        if (-BorderY > transform.position.y && _rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_rigidbody.velocity.y);
            _audioSource.Play();
            _particleSystem.gameObject.transform.position = transform.position;
            _particleSystem.Play();
        }

        //Ограничение слева
        if (-_borderX > transform.position.x)
        {
            _gameData.CurrentScorePlayer2++;
            if (_gameData.CurrentScorePlayer2 >= 5)
                _gameData.ResetAllScore();
            
            ResetBall();
        }

        //Ограничение справа
        else if (_borderX < transform.position.x)
        {
            _gameData.CurrentScorePlayer1++;
            if (_gameData.CurrentScorePlayer1 >= 5)
                _gameData.ResetAllScore();
            
            ResetBall();
        }
    }
}