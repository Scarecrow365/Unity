using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class MiniMapCamera : MonoBehaviour
    {
        void LateUpdate()
        {
            if (!PlayerModel.LocalPlayer)
                return;

            Vector3 pos = PlayerModel.LocalPlayer.transform.position;
            pos.y = transform.position.y;
            transform.position = pos;

            transform.rotation = Quaternion.Euler(90, PlayerModel.LocalPlayer.transform.eulerAngles.y, 0);

        }
    }
}
