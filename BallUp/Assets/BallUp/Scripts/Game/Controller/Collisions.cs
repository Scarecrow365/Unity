using UnityEngine;

namespace Game
{
    public class Collisions : MonoBehaviour
    {        
        public GameObject _gameOverMenu;

        void OnCollisionEnter(Collision col)
        {
            if (col.collider.tag == "Platform")
            {                
                PlayerControllerNew.Jump();
                BaseScore._Score += 1;
                MyVFX._jumpcounter += 1;
                Destroy(col.gameObject, 0.2f);
            }  
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Coin")
            {                
                BaseScore._coinScore += 1;
                MyVFX._coincounter += 1;
                Destroy(col.gameObject,0.1f);
            }
            
            if(col.tag == "Abyss")
            {
                Cursor.visible = true;
                Time.timeScale = 0f;
                _gameOverMenu.SetActive(true);
            }
        }
    }
}
