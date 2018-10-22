using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class MultiBarreledFirearms : BaseWeapon
    {
        [SerializeField]
        private Transform[] _firepoint;
        private int _currentFirepoint;
        [SerializeField]
        private int _capacity = 12;
        private int _currentAmmo;
        private bool _showAmmo;

        
        public AudioClip _reloadSound;        
        public AudioClip _noBulletSound;
        public AudioClip _fireSound;

        public override void Fire()
        {
            if (!TryShoot())
                return;

            
            BaseAmmo bullet = ObjectsPool.Instance.GetObjects(_bulletId) as BaseAmmo;
            bullet.Initialize(_firepoint[_currentFirepoint], _bulletPower);

            _currentFirepoint++;
            if (_currentFirepoint >= _firepoint.Length)
                _currentFirepoint = 0;
        }

        public override void Reload()
        {
            _currentAmmo = _capacity;
            if (_currentAmmo < _capacity)
            {
                _timeout = -_reloadTime;
                GetComponent<AudioSource>().PlayOneShot(_reloadSound);
            }
        }
        public override void DryFire()
        {
            if (_currentAmmo <= 0)
                GetComponent<AudioSource>().PlayOneShot(_noBulletSound);
        }
    }
}