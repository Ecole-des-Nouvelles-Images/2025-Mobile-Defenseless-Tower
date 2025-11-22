using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class TourBase : MonoBehaviour
{
    public DefenseBaseData BaseData;

    public float MaxCoolDown;
    public float CoolDown;
    public float Damage;
    public float Range;
    
    public List<GameObject> targetsInRange = new List<GameObject>();
    public GameObject CurrentTarget;

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        MaxCoolDown = BaseData.CoolDown;
        Damage = BaseData.Damage;
        Range = BaseData.Range;
        gameObject.GetComponent<SphereCollider>().radius = Range;
    }
    
    private void Update()
    {
        targetsInRange.RemoveAll( x => !x);
        CoolDown += Time.deltaTime;
        LookFirstEnemy();
        if (CoolDown >= MaxCoolDown)
        {
            CoolDown = 0;
            Fire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            targetsInRange.Add(other.gameObject);
            CurrentTarget = targetsInRange[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            targetsInRange.Remove(other.gameObject);
            CurrentTarget = targetsInRange[0];
        }
    }

    public abstract void LookFirstEnemy();
    public abstract void Fire();
}
