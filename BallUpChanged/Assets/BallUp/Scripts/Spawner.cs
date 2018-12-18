using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _platform;
    [SerializeField]
    private GameObject _richPlatform;
    [SerializeField]
    private float _delaySpawn;
    private float _spawnTime;

    private float _screenlimit = 3.5f;
    private float _counter;
    float PositionX;

    void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _delaySpawn);
    }

    private void Spawn()
    {
        Vector3 platformPos = new Vector3(Random.Range(-_screenlimit, _screenlimit), 
                                                       transform.position.y,
                                                       transform.position.z);

        // Время спауна richPlatform с периодичностью от 1 до 5
        if (_counter > Random.Range(1, 5))
        {
            Instantiate(_richPlatform, platformPos, transform.rotation);
            _counter = 0;
        }
        else
        {
            Instantiate(_platform, platformPos, transform.rotation);
            _counter += 1;
        }
    }
}
