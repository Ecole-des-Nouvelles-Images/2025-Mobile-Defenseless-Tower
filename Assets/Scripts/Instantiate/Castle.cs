using System;
using Class;
using DG.Tweening;
using UnityEngine;
using Utils;

namespace Instantiate
{
    public class Castle : MonoBehaviour
    {
        private bool _isDead;
        public int Health = 10;
        private Vector3 _baseScale;
        
        private void OnEnable()
        {
            gameObject.tag = "Castle";
            EventBus.OnCastleSpawn?.Invoke(Health);
        }

        private void Awake()
        {
            _baseScale = transform.localScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                int damage = other.gameObject.GetComponent<Enemy>().enemyBaseData.Damage;
                int currentHealth = Health -= damage;
                
                gameObject.transform.DOScale(_baseScale - Vector3.one * 0.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
                EventBus.OnCastleTakedDamage?.Invoke(currentHealth);
                if (Health <= 0 && !_isDead)
                {
                    _isDead = true;
                    Debug.Log("CHATEUA MORT");
                    EventBus.OnLevelFinished?.Invoke();
                }
            }
        }
    }
}
