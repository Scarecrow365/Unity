using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class Firearms : BaseWeapon
    {
        [SerializeField]
        private Transform _firepoint;
        public int _capacity;
        public int _currentAmmo;       
        private bool _canShoot = true;

        
        public AudioClip _reloadSound;        
        public AudioClip _noBulletSound;
        public AudioClip _fireSound;

        void Start()
        {
            _currentAmmo = _capacity;
        }

        public override void Fire()
        {
            if (!TryShoot())
                return;

            if (_canShoot)
            {
                BaseAmmo bullet = ObjectsPool.Instance.GetObjects(_bulletId) as BaseAmmo;
                bullet.Initialize(_firepoint, _bulletPower);
                _currentAmmo--;
                GetComponent<AudioSource>().PlayOneShot(_fireSound);
            }
            
                
            if (_currentAmmo <= 0)
            {
               DryFire();
               return;
            }            
        }

        public override void Reload()
        {
            if (!TryReload())
                return;

            if (_currentAmmo < _capacity)
            {
                GetComponent<AudioSource>().PlayOneShot(_reloadSound);
                _currentAmmo = _capacity;                
            }
            
            _canShoot = true;
        }

        public override void DryFire()
        {
            _canShoot = false;
            _currentAmmo = 0;
            GetComponent<AudioSource>().PlayOneShot(_noBulletSound);
        }
    }
}
