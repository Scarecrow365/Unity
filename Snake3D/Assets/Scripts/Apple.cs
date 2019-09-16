using UnityEngine;

public class Apple : MonoBehaviour
{
    private GameManage _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManage>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Snake"))
            _gameManager.DestroyFood(gameObject);
    }
}
