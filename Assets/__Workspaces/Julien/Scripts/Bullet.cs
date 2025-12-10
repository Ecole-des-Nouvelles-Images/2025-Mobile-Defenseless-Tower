using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public GameObject Target;
    public float Damage;
    public float Speed;
    
    public abstract void SetUp(GameObject target, float damage,  float speed);
}
