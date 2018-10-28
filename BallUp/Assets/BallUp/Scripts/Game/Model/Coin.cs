using UnityEngine;

namespace Game
{
    public class Coin : MonoBehaviour
    {
        private float rotationSpeed = 100;
        private float _angleRot;
        
        void Update()
        {
            RotateCoin();
        }

        private void RotateCoin()
        {
            _angleRot = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * _angleRot, Space.World);
        }
    }
}