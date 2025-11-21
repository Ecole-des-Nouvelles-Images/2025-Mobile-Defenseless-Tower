using System;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private GameObject _parentEmpty;
    
    public EnemyData EnemyData;

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
        _speed = EnemyData.Speed;
        _maxHealth = EnemyData.Health;
        _health = _maxHealth;
        _numberToSpawn = EnemyData.NumberToSpawn;
        
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
        float randX = Random.Range(EnemyData.OffsetX.x, EnemyData.OffsetX.y);
        float randZ = Random.Range(EnemyData.OffsetZ.x, EnemyData.OffsetZ.y);
        transform.position = new Vector3(transform.position.x + randX, transform.position.y + EnemyData.OffsetUp, transform.position.z + randZ);
    }
}
