using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public abstract class BaseAmmo : BaseSceneObject, IPoolable
    {

        [SerializeField]
        protected float _minDamage = 1f;
        [SerializeField]
        protected float _maxDamage = 100f;

        public abstract void Initialize(Transform firepoint, float force);

        public abstract string PoolId { get; }

        public abstract int ObjectCount { get; }
        
        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
