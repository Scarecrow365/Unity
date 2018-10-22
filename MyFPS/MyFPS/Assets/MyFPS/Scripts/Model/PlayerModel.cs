using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PlayerModel : BaseSceneObject, IDamageble
    {

        public static PlayerModel LocalPlayer { get; private set; }

        [SerializeField]
        private float _maxHealth;
        public float MaxHealth { get { return _maxHealth; } }
        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth { get { return _currentHealth; } }
        public bool IsAlive { get { return _currentHealth > 0; } }

        public BaseWeapon[] Weapons;

        protected override void Awake()
        {
            if (LocalPlayer)
                DestroyImmediate(gameObject);
            else
                LocalPlayer = this;

            base.Awake();

            Weapons = GetComponentsInChildren<BaseWeapon>(true);
        }

        public void GetDamage(float damage)
        {
            if (_currentHealth > MaxHealth)
                _currentHealth = 100;

            if (!IsAlive)
                return;

            _currentHealth -= damage;

            if (!IsAlive)
                Death();
        }

        public void Death()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
