using System;
using Unity.Mathematics;
using UnityEngine;

public class Canon : TourBase
{
    [Header("Only for canon")] 
    public GameObject PivotRotation;
    public GameObject SpawnerBullet;
    
    public override void LookFirstEnemy()
    {
        if (targetsInRange[0] != null)
        {
            PivotRotation.transform.LookAt(targetsInRange[0].transform);
        }
    }

    public override void Fire()
    {
        GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, quaternion.identity);
        bulletCanon.GetComponent<BulletCanon>().SetUp(targetsInRange[0], Damage);
    }
}
