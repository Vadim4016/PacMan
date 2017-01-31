using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class MazeFoodCount : MonoBehaviour
    {
        public int foodCount;
        public UnityEvent FoodEmpty;

        void Start () {
            foodCount = GameObject.FindGameObjectsWithTag("Food").Length;
        }

        void OnEnable()
        {
            PacmanCollision.GhostCollisionEvent += () => foodCount--;
        }
        
        void Update () {
            if (foodCount <= 0)
            {
                FoodEmpty.Invoke();
            }
        }
    }
}
