using UnityEngine;

namespace Game
{
    public class PlayerControllerNew : MonoBehaviour
    {
        float PositionX;
        public float Sensetivity = 3;
        private static float jumpHigh = 0.9f;
        private static Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            PositionX += Input.GetAxis("Mouse X") * Sensetivity * Time.deltaTime;
            transform.position = new Vector3(PositionX, transform.position.y, transform.position.z);
        }

        public static void Jump()
        {
            var g = Physics.gravity.magnitude;
            var vSpeed = Mathf.Sqrt(2 * g * jumpHigh);
            rb.velocity = new Vector3(0, vSpeed, 0);
        }
    }
}
