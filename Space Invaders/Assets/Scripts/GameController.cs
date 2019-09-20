using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private float _shootingInterval;
    [SerializeField] private GameObject _enemyBulletPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private float _maximumMovingInterval;
    [SerializeField] private float _minimumMovingInterval;
    [SerializeField] private float _movingDistance;
    [SerializeField] private float _horizontalLimit;

    private float _movingInterval;
    private float _movingDirection = 1f;
    private float _shootingTimer;
    private float _movingTimer;
    private int _maxEnemyCount;
    private Level _level;
    
    
    private void Start()
    {
        _movingInterval = _maximumMovingInterval;
        _shootingTimer = _shootingInterval;
        _level = FindObjectOfType<Level>();
        _maxEnemyCount = _level.CountAllShips();
    }

    private void Update()
    {
        int currentEnemyCount = _level.CountAllShips();
        
        _shootingTimer -= Time.deltaTime;
        if (currentEnemyCount > 0 && _shootingTimer <= 0f)
            EnemyShipsShooting();
        

        _movingTimer -= Time.deltaTime;
        if (_movingTimer <= 0)
        {
            float difficulty = 1f - (float) currentEnemyCount / _maxEnemyCount;
            _movingInterval = _maximumMovingInterval - (_maximumMovingInterval - _minimumMovingInterval) * difficulty;
            
            EnemyShipsMoving();

        }
    }

    private void EnemyShipsShooting()
    {
        _shootingTimer = _shootingInterval;

        Enemy[] enemies = _enemyContainer.GetComponentsInChildren<Enemy>();
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
            
        Instantiate(_enemyBulletPrefab, randomEnemy.transform.position, Quaternion.identity);
    }

    private void EnemyShipsMoving()
    {
        
        _movingTimer = _movingInterval;
        _enemyContainer.transform.position = new Vector2(
            _enemyContainer.transform.position.x + (_movingDistance * _movingDirection),
            _enemyContainer.transform.position.y);
        
        if (_movingDirection > 0)
        {
            float rightMostPosition = 0f;
            foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            {
                if (enemy.transform.position.x > rightMostPosition)
                    rightMostPosition = enemy.transform.position.x;
            }

            if (rightMostPosition > _horizontalLimit)
            {
                _movingDirection *= -1;

                _enemyContainer.transform.position = new Vector2(
                    _enemyContainer.transform.position.x,
                    _enemyContainer.transform.position.y - _movingDistance);
            }
        }
        else
        {
            float LeftMostPosition = 0f;
            foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            {
                if (enemy.transform.position.x < LeftMostPosition)
                    LeftMostPosition = enemy.transform.position.x;
            }

            if (LeftMostPosition < -_horizontalLimit)
            {
                _movingDirection *= -1;

                _enemyContainer.transform.position =
                    new Vector2(_enemyContainer.transform.position.x,
                        _enemyContainer.transform.position.y - _movingDistance);
            }
        }
    }
}
