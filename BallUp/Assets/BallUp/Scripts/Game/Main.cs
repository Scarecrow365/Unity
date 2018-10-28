using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Main : MonoBehaviour
    {

        public static Main Instance { get; private set; }        

        void Awake()
        {
            Time.timeScale = 0f;
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }
    }
}
