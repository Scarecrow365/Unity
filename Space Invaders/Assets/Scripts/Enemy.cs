using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;

    private Level _level;
    private void Start()
    {
        CountShips();
    }

    private void CountShips()
    {
        _level = FindObjectOfType<Level>();
        if (_level != null)
            _level.CountShips();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerBullet")) return;
        GameObject effect = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        _level.DestroyShip();
        Destroy(gameObject);
        Destroy(effect, 2f);
        Destroy(other.gameObject);
    }
}
