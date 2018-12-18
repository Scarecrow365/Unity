using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPool : MonoBehaviour
{    
    [SerializeField]
    private float _delaySpawn;

    private float _screenlimit = 4f;
    private float _counter;
    float PositionX;

    private ObjectPooler _objectPooler;

    #region Singletone
    
    public static SpawnerPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        Invoke("Spawn",0);
        //InvokeRepeating("Spawn", 0, _delaySpawn);
        _objectPooler = ObjectPooler.Instance;
    }

    public void Spawn()
    {
        Vector3 platformPos = new Vector3(Random.Range(-_screenlimit, _screenlimit), 
                                                       transform.position.y,
                                                       transform.position.z);

        // Время спауна richPlatform с периодичностью от 1 до 5
        if (_counter > Random.Range(1, 5))
        {
            _objectPooler.SpawnFromPool("RichPlatform", platformPos, Quaternion.identity);
            _counter = 0;
        }
        else
        {
            _objectPooler.SpawnFromPool("Platform", platformPos, Quaternion.identity);
            _counter += 1;
        }
    }
}
