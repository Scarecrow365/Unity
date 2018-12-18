using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float _speed = 5f;

    private float _movementz;

    public void OnObjectSpawn()
    {
        _movementz = _speed * Time.deltaTime;
        transform.position += new Vector3(0, 0, -_movementz);
    }

    public void Update()
    {
        OnObjectSpawn();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player"))
        {
            SpawnerPool.Instance.Spawn();
        }
    }
}
