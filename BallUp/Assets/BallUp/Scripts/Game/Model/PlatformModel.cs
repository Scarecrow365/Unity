using UnityEngine;

namespace Game
{
    public class PlatformModel : MonoBehaviour
    {       
        private float _speed = 5.8f;
        private float _movementZ;        

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            _movementZ = _speed * Time.deltaTime;            
            if (transform.position.z == 0)
            {
                _movementZ = 0;
            }
            else
                transform.position += new Vector3(0, 0, _movementZ * -1);
        }        
    }
}
