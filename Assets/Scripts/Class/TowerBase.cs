using System.Collections.Generic;
using DG.Tweening;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Class
{
    public abstract class TowerBase : MonoBehaviour, IFreezable
    {
        [SerializeField] private bool _inPause;
        
        [SerializeField] private List<Renderer> _renderer = new List<Renderer>();
        
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
            Range = BaseData.Range + 1;
            gameObject.GetComponent<SphereCollider>().radius = Range;
            MaxCoolDown = BaseData.CoolDown;
            Damage = BaseData.Damage;
            Range = BaseData.Range;
            gameObject.GetComponent<SphereCollider>().radius = Range;
        }
    
        private void Update()
        {
            if (_inPause) return;
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
            _inPause = true;
        }

        private void OnResume()
        {
            _inPause = false;
        }

        public void Freeze()
        {
            _inPause = true;
           
            
            
            foreach (Renderer renderer in _renderer)
            {
                DOTween.To(
                    () => 0f,
                    value =>
                    {
                        renderer.material.SetFloat("_FreezeAmount", value);
                    },
                    0.5f,
                    1f
                );
            }
        }

        public void Unfreeze()
        {
            _inPause = false;
            
            foreach (Renderer renderer in _renderer)
            {
                DOTween.To(
                    () => 0.5f,
                    value =>
                    {
                        renderer.material.SetFloat("_FreezeAmount", value);
                    },
                    0f,
                    1f
                );
                
            }
        }
    }
}
