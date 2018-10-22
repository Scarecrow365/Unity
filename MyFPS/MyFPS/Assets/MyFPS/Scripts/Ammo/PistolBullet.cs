using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PistolBullet : BaseAmmo
    {
        [SerializeField]
        private int _bulletsCount = 50;
        [SerializeField]
        private string _poolId = "Bullet1";
        [SerializeField]
        private float _destroyTime = 10f;
        [SerializeField]
        private LayerMask _layerMask;

        private bool _isHitted;
        private float _speed;

        public override void Initialize(Transform firepoint, float force)
        {
            transform.position = firepoint.position;
            transform.rotation = firepoint.rotation;

            CancelInvoke();
            _isHitted = false;
            _speed = force;
            Invoke("Disable", _destroyTime);

            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (_isHitted)
                return;

            Vector3 finalPos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {
                _isHitted = true;
                transform.position = hit.point;

                IDamageble damageble = hit.collider.GetComponent<IDamageble>();

                if (damageble != null)
                    damageble.GetDamage(Random.Range(_minDamage, _maxDamage));

                Disable();
            }
            else
                transform.position = finalPos;
        }
        public override int ObjectCount { get { return _bulletsCount; } }

        public override string PoolId { get { return _poolId; } } 
    }
    
    
}
