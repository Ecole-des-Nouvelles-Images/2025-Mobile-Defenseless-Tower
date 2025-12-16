using System;
using Class;
using DG.Tweening;
using Managers;
using UnityEngine;
using Utils;

namespace Instantiate
{
    public class Castle : MonoBehaviour
    {
        private bool _isDead;
        public int Health = 10;
        private Vector3 _baseScale;
        [SerializeField] private GameObject _heatVfx;
        
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
                Vector3 position = new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 3, gameObject.transform.position.z);
                SpawnManager.Instance.SpawnVfxInPosition(_heatVfx, position);
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
