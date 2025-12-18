using Class;
using Managers;
using UnityEngine;

namespace Instantiate
{
    public class BulletBombe : Bullet
    {
        [Header("Bombe")] 
        public float RadiusExplosion;
        public GameObject ExplosionVFX;
    
    
        public override void SetUp(GameObject target, float damage, float speed)
        {
            Speed = speed;
            Target = target;
            Damage = damage;
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
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, RadiusExplosion);
                
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        hitCollider.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
                    }
                }
                SpawnManager.Instance.SpawnVfxInPosition(ExplosionVFX, Target.transform.position);
                Destroy(gameObject);
            }
        }
    }
}
