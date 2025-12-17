using Class;
using DG.Tweening;
using Instantiate;
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class Arbalette : TowerBase
    {
        [Header("Only for Arbalette")] 
        public GameObject PivotRotation;
        public GameObject SpawnerBullet;
        public GameObject ArbaletteGm;

        public override void LookFirstEnemy()
        {
            if (targetsInRange != null && targetsInRange.Count > 0)
            {
                Vector3 posTarget = targetsInRange[0].transform.position;
                Vector3 baseRotation = PivotRotation.transform.localRotation.eulerAngles;
                PivotRotation.transform.LookAt(posTarget);
                PivotRotation.transform.localRotation = Quaternion.Euler(new Vector3(baseRotation.x, PivotRotation.transform.eulerAngles.y, baseRotation.z));
            }
        }

        public override void Fire()
        {
            base.Fire();
            GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, quaternion.identity);
            bulletCanon.GetComponent<Bullet>().SetUp(targetsInRange[0], Damage, BaseData.BulletSpeed);
            ArbaletteGm.transform.DOLocalMoveZ(ArbaletteGm.transform.localPosition.z - 0.1f, 0.1f).SetLoops(2, LoopType.Yoyo);
        }
    }
}
