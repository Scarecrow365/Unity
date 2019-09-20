using UnityEngine;

public class Level : MonoBehaviour
{
    private int _enemyShips;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = GetComponent<SceneLoader>();
    }

    public void CountShips()
    {
        _enemyShips++;
    }

    public int CountAllShips()
    {
        return _enemyShips;
    }

    public void DestroyShip()
    {
        _enemyShips--;

        if (_enemyShips <= 0)
            _sceneLoader.ReloadScene();
    }
}
