using UnityEngine;

namespace Assets.Scripts
{
    public class Pause : MonoBehaviour
    {
        public Canvas pauseCanvas;

        private bool _isPaused;
        private Animator _amim;

        void Start()
        {
            _amim = pauseCanvas.GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleTimeScale();
            }
        }

        /// <summary>
        /// Continue game (hide pause)
        /// </summary>
        public void Continue()
        {
            ToggleTimeScale();
        }

        /// <summary>
        /// Close game and go to Windows
        /// </summary>
        public void Exit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show or Hide window of pause
        /// </summary>
        private void ToggleTimeScale()
        {
            if (_isPaused)
            {
               HidePause();
            }
            else
            {
                ShowPause();
            }
        }

        /// <summary>
        /// Show pause
        /// </summary>
        private void ShowPause()
        {
            pauseCanvas.gameObject.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
        }

        /// <summary>
        /// Hide pause
        /// </summary>
        private void HidePause()
        {
            pauseCanvas.gameObject.SetActive(false);
            _isPaused = false;
            Time.timeScale = 1;
        }
    }
}
