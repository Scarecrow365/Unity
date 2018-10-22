using UnityEngine;

namespace MyFPS
{
    public class InteractableCar : BaseInteractableObjectModel
    {
        [SerializeField]
        private AudioClip _Sound;

        public override void Interact(PlayerModel player)
        {
            GetComponent<AudioSource>().PlayOneShot(_Sound);
        }
    }
}
