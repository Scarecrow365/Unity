using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Paddle[] _paddles;
    private const float Percent = 0.0085f;

    private void Awake()
    {
        ResetBallPosition();
        ResetPaddlesPosition();
    }

    private void ResetBallPosition() => _ball.transform.position = Vector3.zero;
    private void ResetPaddlesPosition()
    {
        Vector3 newPos = new Vector3((Screen.width * Percent), 0, 0);
        foreach (Paddle paddle in _paddles)
            paddle.transform.position = paddle.IsAFirstPlayer() ? -newPos : newPos;
    }
}