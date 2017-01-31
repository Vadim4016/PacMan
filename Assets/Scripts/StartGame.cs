using UnityEngine;

namespace Assets.Scripts
{
    public class StartGame : MonoBehaviour
    {
        private bool IsStarted;

        void Awake()
        {
            Time.timeScale = 0;
            IsStarted = false;
        }

        void Update()
        {
            if (!IsStarted)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 1;
                }
            }
        }
    }
}
