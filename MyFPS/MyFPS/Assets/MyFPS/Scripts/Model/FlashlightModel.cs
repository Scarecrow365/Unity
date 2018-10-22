using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyFPS
{
    public class FlashlightModel : MonoBehaviour
    {
        private Light _light;

        public static UnityAction<float> OnFillAmountChanged;
        public float FillAmount { get; private set; }

        private float _drainmultiple = 2f;
        private float _rechargeTime = 10f;

        public bool IsOn
        {
            get
            {
                if (!_light) return false;
                return _light.enabled;
            }
        }

        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        private void OnEnable()
        {

            StartCoroutine(ChangeFill());
        }

        private void OnDisable()
        {
            StopCoroutine(ChangeFill());            
        }

        public void On()
        {
            if(FillAmount < 0.3f)            
                return;
            
            _light.enabled = true;
        }

        public void Off()
        {
            _light.enabled = false;
        }

        public void Switch()
        {
            if (IsOn)
                Off();
            else
                On();
        }
        private IEnumerator ChangeFill()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);

                if (IsOn)                    
                {
                    FillAmount = Mathf.Clamp01(FillAmount - (1f / (_rechargeTime * _drainmultiple) * 0.5f));
                    if (FillAmount <= 0f)
                        Off();
                }
                else
                {
                    FillAmount = Mathf.Clamp01(FillAmount + (1f / _rechargeTime * 0.5f));
                }
                if (OnFillAmountChanged != null)
                    OnFillAmountChanged(FillAmount);
            }
        }
    }
}