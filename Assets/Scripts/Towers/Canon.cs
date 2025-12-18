using Class;
using DG.Tweening;
using Instantiate;
using Managers;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Towers
{
    public class Canon : TowerBase
    {
        [Header("Only for canon")] 
        public GameObject PivotRotation;
        public GameObject SpawnerBullet;
        public GameObject CanonGm;

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
            base.Fire();
            GameObject bulletCanon = Instantiate(BaseData.ProjectilPrefab, SpawnerBullet.transform.position, quaternion.identity);
            bulletCanon.GetComponent<Bullet>().SetUp(targetsInRange[0], Damage, BaseData.BulletSpeed);
            CanonGm.transform.DOLocalMoveZ(CanonGm.transform.localPosition.z - 0.1f, 0.1f).SetLoops(2, LoopType.Yoyo);
            SpawnManager.Instance.SpawnVfxInPosition(BaseData.FireVisual, SpawnerBullet.transform.position);
        }
    }
}
