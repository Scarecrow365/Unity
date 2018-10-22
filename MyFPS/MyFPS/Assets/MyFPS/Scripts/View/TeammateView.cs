using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class TeammateView : BaseSceneObject
    {

        private Teammate _teammate;

        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(Initialize());
        }

        IEnumerator Initialize()
        {
            yield return new WaitWhile(() => Main.Instance == null);

            _teammate = GetComponentInParent<Teammate>();
            TeammateController.OnTeammateSelected += OnTeammateSelected;
            IsVisible = false;
        }
        private void OnDestroy()
        {
            TeammateController.OnTeammateSelected -= OnTeammateSelected;
        }

        private void OnTeammateSelected(Teammate teammate)
        {
            IsVisible = teammate == _teammate;
        }
    }
}
