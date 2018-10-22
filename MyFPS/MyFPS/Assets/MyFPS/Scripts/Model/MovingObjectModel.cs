using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class MovingObjectModel : BaseInteractableObjectModel
    {
        [SerializeField]
        private float _throwForce = 10f;

        public override void Interact(PlayerModel player)
        {
            Rigidbody.AddForce((transform.position - player.transform.position) * _throwForce, ForceMode.Impulse);
        }
    }
}