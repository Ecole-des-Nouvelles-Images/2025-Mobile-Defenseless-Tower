using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;

    private float _speed;
    private float _maxHealth;
    private float _health;
    
    public SplineContainer Container;

    private void Update()
    {
        
    }

    private void Start()
    {
        _speed = EnemyData.Speed;
        _maxHealth = EnemyData.Health;
        _health = _maxHealth;
    }

    public void GoMove()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            Container.Evaluate(0, i, out float3 pos, out float3 tangent, out _);
            // Sur la spline[0], je prend la pos i, la pos est normalizé, elle me renvoie la pos dans le monde.
            Vector3 lastPosVec = pos;
            
            Vector3Int vector3Int = new Vector3Int(Mathf.RoundToInt(lastPosVec.x),0,Mathf.RoundToInt(lastPosVec.z));
            
            
        }
    }
}
