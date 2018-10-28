using UnityEngine.SceneManagement;
using UnityEngine;

namespace Game
{
    public class ButtonsMenu : MonoBehaviour {

        public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Exit()
        {
            Application.Quit();
        } 

        public void NextScene()
        {
            SceneManager.LoadScene("Game");
        }

        public void StartGame()
        {
            BaseScore._Score = 0;
            BaseScore._coinScore = 0;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }
}
