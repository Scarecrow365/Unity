using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BaseScore : MonoBehaviour
    {
        Text _textScore;
        //перелючатель на счётчик jump/coin
        public bool _jumpSwitch = false;
        public bool _coinSwitch = false;
        public static int _Score = 0;
        public static int _coinScore = 0;

        void Awake()
        {
            _textScore = GetComponent<Text>();
        }

        void Update()
        {
            JumpScore();
            CoinScore();            
        }

        private void JumpScore()
        {
            if (_jumpSwitch)
                _textScore.text = _Score.ToString();             
        }

        private void CoinScore()
        {
            if(_coinSwitch)
            _textScore.text = _coinScore.ToString();
        }
    }
}
