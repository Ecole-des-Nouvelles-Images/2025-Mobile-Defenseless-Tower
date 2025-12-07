using Class;
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
            EventBus.OnCastleSpawn?.Invoke(Health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                int damage = other.gameObject.GetComponent<Enemy>().enemyBaseData.Damage;
                int currentHealth = Health -= damage;
                EventBus.OnCastleTakedDamage?.Invoke(currentHealth);
                if (Health <= 0)
                {
                    EventBus.OnLevelFinished?.Invoke();
                }
            }
        }
    }
}
