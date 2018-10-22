using UnityEngine;

namespace MyFPS
{

    public class Spawner : MonoBehaviour
    {

        public bool UseRandomWP;

        [SerializeField]
        private Enemy _prefab;

        private Enemy _instance;

        private void Update()
        {
            SpawnerInstance();
        }

        private void SpawnerInstance()
        {
            if (!_instance)
            {
                _instance = Instantiate(_prefab, transform.position, transform.rotation);
                _instance.Initialize(this);
            }
        }
    }
}