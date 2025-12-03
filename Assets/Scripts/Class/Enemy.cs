using System;
using Interface;
using ScriptableObjectsScripts;
using UnityEngine;
using UnityEngine.Splines;
using Utils;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace Class
{
    public class Enemy : MonoBehaviour, IDamagable, IHealable
    {
        private GameObject _parentEmpty;
    
        public EnemyBaseData enemyBaseData;

        public EnemyClass EnemyClass;
    
        [SerializeField] private float _speed;
        private float _maxHealth;
        private float _health;
  
        [SerializeField] private Image _healthBar;
        [SerializeField] private SplineAnimate _splineAnimate;
    
        public float Health
        {
            get => _health;
            set
            {
                _healthBar.fillAmount = value / _maxHealth;
                _health = value;
            
                if (_health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

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
            SpawnInEmpty();
        
            _splineAnimate.Container = GameObject.FindGameObjectWithTag("Spline").GetComponent<SplineContainer>();
            _splineAnimate.Play();
            SetUp();
            RandOffset();
        }
    
        public void SetUp()
        {
            _speed = EnemyClass.Speed;
            _maxHealth = EnemyClass.MaxHealth;
            _health = _maxHealth;
        
            _splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            _splineAnimate.MaxSpeed = _speed;
            _splineAnimate.Alignment = SplineAnimate.AlignmentMode.None;
            _splineAnimate.StartOffset = Random.Range(0, 0.01f);

        }

        public void SpawnInEmpty()
        {
            GameObject emptyParent = new GameObject("Enemy_" + gameObject.name + "_Parent");
            emptyParent.tag = "Enemy";
            emptyParent.transform.position = transform.position;
            emptyParent.transform.rotation = transform.rotation;

            transform.SetParent(emptyParent.transform, worldPositionStays: true);

            _splineAnimate = emptyParent.AddComponent<SplineAnimate>();
        }

        public void RandOffset()
        {
            float randX = Random.Range(enemyBaseData.OffsetX.x, enemyBaseData.OffsetX.y);
            float randZ = Random.Range(enemyBaseData.OffsetZ.x, enemyBaseData.OffsetZ.y);
            transform.position = new Vector3(transform.position.x + randX, transform.position.y + enemyBaseData.OffsetUp, transform.position.z + randZ);
        }

        public void TakeDamage(float damaga)
        {
            Health -= damaga;
        }

        public void GetHealth(float health)
        {
            _health = Mathf.Clamp(_health + health, 0, _maxHealth);
            _healthBar.fillAmount = _health / _maxHealth;
        }

        private void OnPause()
        {
            _splineAnimate.Pause();
            print("Speed 0");
        }

        private void OnResume()
        {
            _splineAnimate.Play();
            print("Speed = le speed de la class");
        }
    }
}
