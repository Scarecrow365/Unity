using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class Bullet : MonoBehaviour
    {
        private int _damage = 20;

        void Start()
        {
            Destroy(gameObject, 5f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var ph = collision.collider.GetComponent<PlayerHP>();

            if (ph)
                ph.GetDamage(_damage);

            Destroy(gameObject);
        }
    }
}
