using System.Collections.Generic;
using DG.Tweening;
using Interface;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Class
{
    public abstract class TowerBase : MonoBehaviour, IFreezable
    {
        [SerializeField] private bool _inPause;
        [SerializeField] private bool _inFreez;
        
        [SerializeField] private List<Renderer> _renderer = new List<Renderer>();
        
        public DefenseBaseData BaseData;

        public float MaxCoolDown;
        public float CoolDown;
        public float Damage;
        public float Range;
    
        public List<GameObject> targetsInRange = new List<GameObject>();

        protected virtual void OnEnable()
        {
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
        }

        protected virtual void OnDisable()
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
            if (_inPause || _inFreez) return;
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

        public virtual void Fire()
        {
            SoundManager.Instance.PlayRandomSound(BaseData.FireSounds, gameObject, true);
        }
        
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
            _inFreez = true;
            
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
            _inFreez = false;
            
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
