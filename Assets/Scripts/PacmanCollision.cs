using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PacmanCollision : MonoBehaviour
    {
        public AudioClip cherry;
        public AudioClip food;
        public Text scoreText;

        public delegate void Collision();
        public static event Collision GhostCollisionEvent;
        public static event Collision FoodCollisionEvent;

        private int _oldScore;
        private int _currentScore;
        private AudioSource _audio;

        void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            CheckFoodCollision(other);
            CheckCherryCollision(other);
            CheckGhostCollision(other);

            if (_oldScore != _currentScore)
            {
                _oldScore = _currentScore;
                scoreText.text = _currentScore.ToString();
            }
        }

        /// <summary>
        /// Check collision with Food
        /// </summary>
        /// <param name="other"></param>
        private void CheckFoodCollision(Collider2D other)
        {
            if (other.tag == "Food")
            {
                if (FoodCollisionEvent != null)
                    FoodCollisionEvent();

                if (!_audio.isPlaying)
                {
                    _audio.PlayOneShot(food);
                }
                _currentScore += 10;
                Destroy(other.gameObject);
            }
        }

        /// <summary>
        /// Check collision with Cherry
        /// </summary>
        /// <param name="other"></param>
        private void CheckCherryCollision(Collider2D other)
        {
            if (other.tag == "Cherry")
            {
                _audio.PlayOneShot(cherry);
                _currentScore += 10;
                Destroy(other.gameObject);
            }
        }

        /// <summary>
        /// Check collision with Chost
        /// </summary>
        /// <param name="other"></param>
        private void CheckGhostCollision(Collider2D other)
        {
            if (other.tag == "Ghost")
            {
                if (GhostCollisionEvent != null)
                {
                    GhostCollisionEvent();
                }

                Destroy(this.gameObject);
            }
        }
    }
}
