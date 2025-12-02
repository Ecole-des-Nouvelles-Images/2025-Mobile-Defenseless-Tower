using Class;
using Instantiate;
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
                PivotRotation.transform.LookAt(targetsInRange[0].transform);
            }
        }

        public override void Fire()
        {
            GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, quaternion.identity);
            bulletCanon.GetComponent<BulletCanon>().SetUp(targetsInRange[0], Damage);
        }
    }
}
