using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class WeaponController : BaseController
    {
        private BaseWeapon[] _weapons;
        private int _currentWeapon;
        private int _capacityGun = 2;
        private int _currentAmmoGun = 1;

        private void Awake()
        {
            _weapons = PlayerModel.LocalPlayer.Weapons;

            for (int i = 0; i < _weapons.Length; i++)            
                _weapons[i].IsVisible = i == 0;            
        }        

        public void ChangeNextWeapon()
        {
            _weapons[_currentWeapon].IsVisible = false;
            _currentWeapon++;
            if (_currentWeapon >= _weapons.Length)
                _currentWeapon = 0;
            _weapons[_currentWeapon].IsVisible = true;
        }

        public void ChangePreviousWeapon()
        {
                _weapons[_currentWeapon].IsVisible = false;
                _currentWeapon--;
                if (_currentWeapon < 0)
                    _currentWeapon = _weapons.Length - 1;
                _weapons[_currentWeapon].IsVisible = true;            
        }        

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
                _weapons[_currentWeapon].Fire();
        }

        public void Reload()
        {
            if (_capacityGun > _currentAmmoGun)
                _weapons[_currentWeapon].Reload();
        }

        public void OnGUI()
        {
            //if (_weapons[_currentWeapon].IsVisible == false)
            GUI.Label(new Rect(20, Screen.height - 45, 100, 20), "Ammo: " + "?? " + "/" + " ??");

        }
    }
}
