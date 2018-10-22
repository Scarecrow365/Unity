using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyFPS
{
    public class Waypoint : MonoBehaviour
    {
        public float WaitTime;
        public UnityEvent OnReachEvent;
    }
}
