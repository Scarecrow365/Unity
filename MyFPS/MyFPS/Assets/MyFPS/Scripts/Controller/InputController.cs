using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance.FlashlightController.Switch();

            if (Input.GetButtonDown("Interact"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    BaseInteractableObjectModel obj = hit.collider.GetComponent<BaseInteractableObjectModel>();
                    if (obj)
                        obj.Interact(PlayerModel.LocalPlayer);
                }
            }

            if (Input.GetAxis("ChangeWeapon") < 0 )           
                Main.Instance.WeaponController.ChangeNextWeapon();

            if (Input.GetAxis("ChangeWeapon") > 0)
                Main.Instance.WeaponController.ChangePreviousWeapon();

            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponController.Fire();

            if (Input.GetButton("Teammate"))
                Main.Instance.TeammateController.MoveCommand();

            if (Input.GetButton("Reload"))
                Main.Instance.WeaponController.Reload();
        }
    }
}