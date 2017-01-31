using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour
    {
        public static bool IsGameOver;
        private Animator _anim;

        void Start ()
        {
            _anim = GetComponent<Animator>();
        }

        void OnEnable()
        {
            PacmanCollision.GhostCollisionEvent += ShowGameOver;
        }

        void OnDisable()
        {
            PacmanCollision.GhostCollisionEvent -= ShowGameOver;
        }

        void Update()
        {
            if (IsGameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
            }
        }

        public void ShowGameOver()
        {
            _anim.SetTrigger("GameOver");
            IsGameOver = true;
        }
    }
}
