using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class FlashlightController : BaseController
    {
        private FlashlightModel _model;

        private void Awake()
        {
            _model = FindObjectOfType<FlashlightModel>();
            Off();
        }

        public override void Off()
        {
            base.Off();
            _model.Off();
        }

        public override void On()
        {
            base.On();
            _model.On();
        }

        public void Switch()
        {
            if (IsEnabled)
                Off();
            else
                On();
        }
    }
}