using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, IDamagable
{
    private GameObject _parentEmpty;
    
    [FormerlySerializedAs("EnemyData")] public EnemyBaseData enemyBaseData;

    private float _speed;
    private float _maxHealth;
    private float _health;

    public int _numberToSpawn;

    [SerializeField] private SplineAnimate _splineAnimate;
    
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
        _speed = enemyBaseData.Speed;
        _maxHealth = enemyBaseData.Health;
        _health = _maxHealth;
        _numberToSpawn = enemyBaseData.NumberToSpawn;
        
        _splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
        _splineAnimate.MaxSpeed = _speed;
        _splineAnimate.Alignment = SplineAnimate.AlignmentMode.None;
        _splineAnimate.StartOffset = Random.Range(0, 0.01f);

    }

    public void SpawnInEmpty()
    {
        GameObject emptyParent = new GameObject("Enemy_" + gameObject.name + "_Parent");

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
        _health -= damaga;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar()
    {
        
    }
}
