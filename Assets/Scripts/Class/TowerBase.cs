using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Class
{
    public abstract class TowerBase : MonoBehaviour
    {
        private bool InPause;
        
        public DefenseBaseData BaseData;

        public float MaxCoolDown;
        public float CoolDown;
        public float Damage;
        public float Range;
    
        public List<GameObject> targetsInRange = new List<GameObject>();

        private void OnEnable()
        {
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
        }

        private void OnDisable()
        {
            EventBus.OnGamePaused -= OnPause;
            EventBus.OnGameResume -= OnResume;
        }
        
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
            if (InPause) return;
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
        
        private void OnPause()
        {
            InPause = true;
        }

        private void OnResume()
        {
            InPause = false;
        }
    }
}
