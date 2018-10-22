using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class ObjectsPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _objects;

        private Dictionary<string, Queue<IPoolable>> _objectsDict = new Dictionary<string, Queue<IPoolable>>();

        public static ObjectsPool Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }

        private void Start()
        {
            foreach (var o in _objects)
            {
                IPoolable poolObj = o.GetComponent<IPoolable>();
                if (poolObj == null)
                    continue;

                Queue<IPoolable> queue = new Queue<IPoolable>();
                for (int i = 0; i < poolObj.ObjectCount; i++)
                {
                    GameObject go = Instantiate(o);
                    go.SetActive(false);
                    queue.Enqueue(go.GetComponent<IPoolable>());
                }
                _objectsDict.Add(poolObj.PoolId, queue);
            }
        }
        public IPoolable GetObjects(string poolId)
        {
            if (string.IsNullOrEmpty(poolId))
                return null;
            if (!_objectsDict.ContainsKey(poolId))
                return null;

            IPoolable p = _objectsDict[poolId].Dequeue();
            _objectsDict[poolId].Enqueue(p);
            return p;
        }
    }
}
