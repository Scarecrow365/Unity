using UnityEngine;

namespace MyFPS
{
    public class InteractableHP : BaseInteractableObjectModel
    { 
        public override void Interact(PlayerModel player)
        {
            IDamageble damageble = PlayerModel.LocalPlayer.GetComponent<IDamageble>();
            damageble.GetDamage(-50);
            DestroyImmediate(gameObject);
        }
    }
}
