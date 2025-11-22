using System;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    public GameObject Target;
    public float Speed;

    public void SetUp(GameObject target)
    {
        Target = target;
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target)
        {
            Debug.Log(other.gameObject + " was hited ");
            Destroy(gameObject);
        }
    }
}
