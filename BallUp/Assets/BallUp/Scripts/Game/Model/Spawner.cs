using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _platform;
        [SerializeField]
        private GameObject _richPlatform;

        private float _spawnTime = 0.85f;
        private float _minPosition = -4f;
        private float _maxPosition = 4f;
        private float _timer;
        private int _counter;

        void Start()
        {
            Spawn();
        }

        void FixedUpdate()
        {
            _timer -= Time.deltaTime;
            Spawn();
        }

        private void Spawn()
        {
            
            if (_timer <= 0)
            {
                Vector3 platformPos = new Vector3(Random.Range(_minPosition, _maxPosition), transform.position.y, transform.position.z);
                Instantiate(_platform, platformPos, transform.rotation);                
                _counter += 1;
                if(_counter > Random.Range(1, 5))
                {
                    Instantiate(_richPlatform, platformPos, transform.rotation);
                    _counter = 0;
                }
                _timer = _spawnTime;
            }
        }        
    }
}
    
