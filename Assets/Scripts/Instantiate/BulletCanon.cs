using Interface;
using UnityEngine;
using Utils;

namespace Instantiate
{
    public class BulletCanon : MonoBehaviour
    {
        public GameObject Target;
        public float Speed;
        public float Damage;

        private float _speedSave;
        
        private void OnEnable()
        {
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
        }

        private void OnDisable()
        {
            EventBus.OnGamePaused -= OnPause;
            EventBus.OnGameResume -= OnResume;
        }
        
        public void SetUp(GameObject target, float damage)
        {
            Damage = damage;
            Target = target;
        }
    
        private void Update()
        {
            if (Target == null)
            {
                Destroy(gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Target)
            {
                Debug.Log(other.gameObject + " was hited ");
                other.gameObject.GetComponent<IDamagable>().TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
        
        private void OnPause()
        {
            _speedSave = Speed;
            Speed = 0;
        }

        private void OnResume()
        {
            Speed = _speedSave;
        }
    }
}
