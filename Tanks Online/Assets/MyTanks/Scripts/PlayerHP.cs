using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Tanks
{
    public class PlayerHP : NetworkBehaviour
    {

        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private Image _fillImage;

        public int MaxHP = 100;
        [SyncVar(hook = "OnHealthChanged")]
        public int CurrentHP = 100;

        //private void LateUpdate()
        //{
        //    _canvas.LookAt(Camera.main.transform, Vector3.up);
        //}

        public void GetDamage(int damage)
        {
            if (!isServer)
                return;
            if (CurrentHP <= 0)
                return;

            CurrentHP -= damage;

            if (CurrentHP <= 0)
                RpcRespawn();
        }

        private void OnHealthChanged (int health)
        {
            CurrentHP = health;
            _fillImage.fillAmount = (float)CurrentHP / MaxHP;
        }

        [ClientRpc]
        private void RpcRespawn()
        {
            transform.position = Vector3.up * 2f;
            CurrentHP = MaxHP;
        }

    }
}
