using Class;
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class Canon : TowerBase
    {
        [Header("Only for canon")] 
        public GameObject PivotRotation;
        public GameObject SpawnerBullet;

       

        public override void LookFirstEnemy()
        {
            if (targetsInRange != null && targetsInRange.Count > 0)
            {
                Vector3 posTarget = targetsInRange[0].transform.position;
                PivotRotation.transform.LookAt(new Vector3(posTarget.x, 0, posTarget.z));
            }
        }

        public override void Fire()
        {
            GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, quaternion.identity);
            bulletCanon.GetComponent<Bullet>().SetUp(targetsInRange[0], Damage, BaseData.BulletSpeed);
        }

        
    }
}
