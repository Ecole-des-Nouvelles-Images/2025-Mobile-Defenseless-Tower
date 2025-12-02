using System.Collections.Generic;
using UnityEngine;

namespace Class
{
    public abstract class TowerBase : MonoBehaviour
    {
        public DefenseBaseData BaseData;

        public float MaxCoolDown;
        public float CoolDown;
        public float Damage;
        public float Range;
    
        public List<GameObject> targetsInRange = new List<GameObject>();

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
            if (CoolDown >= MaxCoolDown && targetsInRange.Count > 0)
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
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                targetsInRange.Remove(other.gameObject);
            }
        }

        public abstract void LookFirstEnemy();
        public abstract void Fire();
    }
}
