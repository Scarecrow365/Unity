using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class EnemyController : BaseController
    {

        private List<Enemy> _botlist = new List<Enemy>();
        private Transform _targetTransform;

        private void Start()
        {
            _targetTransform = PlayerModel.LocalPlayer.transform;

            foreach (var bot in FindObjectsOfType<Enemy>())
                AddBot(bot);
        }

        public void AddBot(Enemy bot)
        {
            if (_botlist.Contains(bot))
                return;
            _botlist.Add(bot);
            bot.SetTarget(_targetTransform);
        }

        public void RemoveBot(Enemy bot)
        {
            if (!_botlist.Contains(bot))             
                return;
            _botlist.Remove(bot);
            
        } 

    }
}
