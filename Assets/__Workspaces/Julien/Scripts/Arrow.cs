using Class;
using Instantiate;
using Interface;
using Managers;
using UnityEngine;

public class Arrow : Bullet
{
    public override void SetUp(GameObject target, float damage, float speed)
    {
        Speed = speed;
        Damage = damage;
        Target = target;
        
        transform.LookAt(target.transform);
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
            if (other.gameObject == Target)
            {
                other.gameObject.GetComponent<IDamagable>().TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
