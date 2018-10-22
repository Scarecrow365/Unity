using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public abstract class BaseWeapon : BaseSceneObject
    {

        [SerializeField]
        protected string _bulletId;

        [SerializeField]
        protected float _bulletPower;

        [SerializeField]
        protected float _reloadTime;
        protected float _reloadTimer;

        [SerializeField]
        protected float _timeout;
        protected float _lastShotTime;

        public abstract void Fire();
        public abstract void Reload();
        public abstract void DryFire();

        protected bool TryShoot()
        {
            if (Time.time - _lastShotTime < _timeout)
                return false;

            _lastShotTime = Time.time;
            return true;
        }

        protected bool TryReload()
        {
            if (Time.time - _reloadTimer < _reloadTime)
                return false;

            _reloadTimer = Time.time;
            return true;
        }
    }
}
