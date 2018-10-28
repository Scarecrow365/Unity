using UnityEngine;

namespace Game
{
    public class MyVFX : MonoBehaviour
    {

        public static int _jumpcounter = 0;
        public static int _coincounter = 0;

        [SerializeField]
        private Transform _firepointJump;
        [SerializeField]
        private GameObject _ParticlesJump;
        [SerializeField]
        private Transform _firepointCoin;
        [SerializeField]
        private GameObject _ParticlesCoin;

        void Update()
        {
            JumpCounter();
            CoinCounter();
        }

        private void JumpCounter()
        {
            if (_jumpcounter >= 3)
            {
                Instantiate(_ParticlesJump, _firepointJump.transform.position, _firepointJump.transform.rotation);
                _jumpcounter = 0;
            }
        }

        private void CoinCounter()
        {
            if (_coincounter >= 5 )
            {
                Instantiate(_ParticlesCoin, _firepointCoin.transform.position, _firepointCoin.transform.rotation);
                _coincounter = 0;
            }
        }
    }
}