using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private bool _isFirstPlayer;
    private const float BorderY = 3.8f;

    private void Update()
    {
        CheckBorders();
    }

    public bool IsAFirstPlayer() => _isFirstPlayer;

    private void CheckBorders()
    {
        //Ограничение сверху
        if (BorderY < transform.position.y)
            transform.position = new Vector2(transform.position.x, BorderY);

        //Ограничение снизу
        if (-BorderY > transform.position.y)
            transform.position = new Vector2(transform.position.x, -BorderY);
    }
}
