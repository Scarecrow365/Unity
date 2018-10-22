using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public abstract class BaseInteractableObjectModel : BaseSceneObject
    {
        public abstract void Interact(PlayerModel player);
    }
}