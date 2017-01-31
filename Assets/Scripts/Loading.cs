using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Loading : MonoBehaviour {

        IEnumerator Start ()
        {
            AsyncOperation loadLavel = SceneManager.LoadSceneAsync("Game");
            yield return loadLavel;
        }
    }
}
