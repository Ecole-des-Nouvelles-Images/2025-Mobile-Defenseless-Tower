using System;
using System.Collections;
using Class;
using DG.Tweening;
using Instantiate;
using Unity.Mathematics;
using UnityEngine;

public class Catapult : TowerBase
{
    [Header("Only for catapult")] 
    public GameObject PivotRotation;
    public GameObject SpawnerBullet;

    public GameObject CatapultShooter;
    
    
    public override void LookFirstEnemy()
    {
        if (targetsInRange != null && targetsInRange.Count > 0)
        {
            Vector3 posTarget = targetsInRange[0].transform.position;
            PivotRotation.transform.LookAt(new Vector3(posTarget.x, transform.position.y, posTarget.z));
        }
    }
    

    public override void Fire()
    {
        GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, Quaternion.identity);
        bulletCanon.GetComponent<Bullet>().SetUp(targetsInRange[0], Damage, BaseData.BulletSpeed);
        FireAnimation();
    }

    private void FireAnimation()
    {
        CatapultShooter.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
        StartCoroutine("ReloadAnimation");
    }
    
    private IEnumerator ReloadAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        CatapultShooter.transform.DOLocalRotate(new Vector3(-50, 0, 0), MaxCoolDown - 0.5f);
    }
}
