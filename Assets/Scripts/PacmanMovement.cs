using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
    public class PacmanMovement : MonoBehaviour
    {
        public float speed = 0.2f;
        
        private Rigidbody2D _rb;
        private Vector2 _dest;
        private Vector2 _lastComand = Vector2.zero;
        
        void Start()
        {
            _dest = transform.position;
            _rb = GetComponent<Rigidbody2D>();
        }
            
        void FixedUpdate()
        {
            if ((Vector2) transform.position == _dest)
            {
                CheckInput();
                _dest = (Vector2)transform.position + _lastComand;

            }

            Vector2 pos = Vector2.MoveTowards(transform.position, _dest, speed);
            _rb.MovePosition(pos);

            ShowAnimation(_dest);
        }

        /// <summary>
        /// Check valid next position
        /// </summary>
        /// <param name="dir">direction</param>
        /// <returns></returns>
        private bool IsValidPos(Vector2 dir)
        {
            Vector2 pos = transform.position;
            RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);

            Debug.DrawLine(pos + dir, pos, Color.red);
            return hit.collider.name != "maze";
        }
        
        /// <summary>
        /// Get input direction
        /// </summary>
        /// <param name="lastDirection"></param>
        private void CheckInput()
        {
            if (Input.GetKey(KeyCode.UpArrow) && IsValidPos(Vector2.up))
                _lastComand = Vector2.up;
            else if (Input.GetKey(KeyCode.RightArrow) && IsValidPos(Vector2.right))
                _lastComand = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow) && IsValidPos(Vector2.down))
                _lastComand = Vector2.down;
            else if (Input.GetKey(KeyCode.LeftArrow) && IsValidPos(Vector2.left))
                _lastComand = Vector2.left;
            else if (!IsValidPos(_lastComand))
            {
                _lastComand = Vector2.zero;
            }
        }

        /// <summary>
        /// Show animation
        /// </summary>
        /// <param name="newPosition"></param>
        private void ShowAnimation(Vector2 newPosition)
        {
            Vector2 dir = newPosition - (Vector2)transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }
}
