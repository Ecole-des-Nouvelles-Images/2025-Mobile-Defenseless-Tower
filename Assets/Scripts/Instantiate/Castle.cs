using System;
using System.Collections.Generic;
using Class;
using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Instantiate
{
    public class Castle : MonoBehaviour
    {
        private bool _isDead;
        public int Health = 10;
        private Vector3 _baseScale;
        [SerializeField] private GameObject _hitVfx;
        [SerializeField] private List<GameObject> _trumpet;
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
                
                transform.DOKill();
                transform.localScale = _baseScale;
                transform.DOScale(_baseScale - Vector3.one * 0.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
                
                
                Vector3 position = new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 3, gameObject.transform.position.z);
                if (_hitVfx) SpawnManager.Instance.SpawnVfxInPosition(_hitVfx, position);
                EventBus.OnCastleTakedDamage?.Invoke(currentHealth);
                if (Health <= 0 && !_isDead)
                {
                    SpawnConfetti();
                    _isDead = true;
                    Debug.Log("CHATEUA MORT");
                    EventBus.OnLevelFinished?.Invoke();
                }
            }
        }

        private void SpawnConfetti()
        {
            foreach (GameObject trumpet in _trumpet)
            {
                trumpet.SetActive(true);
            }
        }
    }
}
