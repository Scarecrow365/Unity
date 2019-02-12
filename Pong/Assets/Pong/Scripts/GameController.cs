using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballPrefab;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Text _score1;
    [SerializeField]
    private Text _score2;
    [SerializeField]
    private float _BallBound = 8.4f;

    private Ball _ball;
    private int score1;
    private int score2;

    void Start ()
    {
	    SpawnBall();
	}

	void Update ()
	{
	    if (_ball != null)
	    {
	        if (_ball.transform.position.x > _BallBound)
	        {
	            score1++;
                Destroy(_ball.gameObject);
	            SpawnBall();
	        }

	        if (_ball.transform.position.x < -_BallBound)
	        {
	            score2++;
                Destroy(_ball.gameObject);
                SpawnBall();
	        }
	    }
        GameOver();
	}

    void SpawnBall()
    {
        GameObject ballInstance = Instantiate(_ballPrefab, transform);

        _ball = ballInstance.GetComponent<Ball>();
        _ball.transform.position = Vector3.zero;

        _score1.text = score1.ToString();
        _score2.text = score2.ToString();
    }

    void GameOver()
    {
        if (score1 >= 5 || score2 >= 5)
        {
            
        }
    }
}
