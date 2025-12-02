using Interface;
using UnityEngine;

namespace Instantiate
{
    public class BulletCanon : MonoBehaviour
    {
        public GameObject Target;
        public float Speed;
        public float Damage;

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
    }
}
