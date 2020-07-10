using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] private float _speed = 1;
    private const float BorderY = 3.8f;

    public void MoveUp(Rigidbody2D rigidbody)
    {
        if (rigidbody.gameObject.transform.position.y > BorderY)
        {
            Stop(rigidbody);
            return;
        }

        rigidbody.velocity = new Vector2(0, _speed);
    }

    public void MoveDown(Rigidbody2D rigidbody)
    {
        if (rigidbody.gameObject.transform.position.y < -BorderY)
        {
            Stop(rigidbody);
            return;
        }

        rigidbody.velocity = new Vector2(0, -_speed);
    }

    public void Stop(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2(0, 0);
    }
}