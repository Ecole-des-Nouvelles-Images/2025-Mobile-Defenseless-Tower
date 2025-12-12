using Class;
using UnityEngine;

namespace Instantiate
{
    public class BulletBombe : Bullet
    {
        [Header("Bombe")] 
        public float RadiusExplosion;
        public ParticleSystem ParticleExplosion;
    
    
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
            if (other.CompareTag("Enemy"))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, RadiusExplosion);
        
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        hitCollider.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
                    }
                }
            
                Destroy(gameObject);
            }
        }
    }
}
