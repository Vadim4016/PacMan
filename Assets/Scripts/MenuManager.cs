using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour {

        public void LoadGame(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
