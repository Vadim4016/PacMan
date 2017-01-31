using UnityEngine;

namespace Assets.Scripts
{
    public class GhostMovement : MonoBehaviour
    {
        public Transform[] waypoints;
        public float speed = 0.3f;

        private int indexWP = 0;
        
        void FixedUpdate()
        {
            if (transform.position != waypoints[indexWP].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position, waypoints[indexWP].position, speed);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            else indexWP = (indexWP + 1) % waypoints.Length;

            // Animation
            Vector2 dir = waypoints[indexWP].position - transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }
}
