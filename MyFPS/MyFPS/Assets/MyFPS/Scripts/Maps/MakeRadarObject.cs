using UnityEngine;
using UnityEngine.UI;

namespace MyFPS
{
    public class MakeRadarObject : MonoBehaviour
    {
        public Image Image;
        private void Start()
        {
            MiniMap.RegisterRadarObject(gameObject, Image);
        }
        private void OnDestroy()
        {
            MiniMap.RemoveRadarObject(gameObject);
        }
    }
}