using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class Tower : MonoBehaviour
    {        
        [SerializeField]
        private float Sensetivity = 20;
        float rotationY;

        void Update()
        {
            Cursor.lockState = CursorLockMode.Locked;            
            rotationY += Input.GetAxis("Mouse X") * Sensetivity * Time.deltaTime;
            transform.localEulerAngles = new Vector3(90, rotationY, -180);
            transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);
        }
    }
}
