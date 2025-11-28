using UnityEngine;
using Utils;

namespace Instantiate
{
    public class Castle : MonoBehaviour
    {
        public int Health = 10;
    
        private void OnEnable()
        {
            gameObject.tag = "Castle";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Health--;
                if (Health <= 0)
                {
                    EventBus.OnLevelFinished?.Invoke();
                }
            }
        }
    }
}
