using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "Scriptable Objects/Defense")]
public class DefenseBaseData : ScriptableObject
{
    public int Price;
    
    public float CoolDown;
    public float Damage;
    public float Range;
    public float BulletSpeed;

    public int WaveHeCanSpawn;
    
    public List<CoordHeurstic> Heurstics = new List<CoordHeurstic>();

    [Header("Prefab")] 
    public GameObject Prefab;
    public GameObject ProjectilPrefab;
    
    [Header("Sound")]
    public List<AudioClip> FireSounds;

    [Header("VFX")] 
    public GameObject FireVisual;
}

[Serializable]
public struct CoordHeurstic
{
    public Vector2Int Coord;
    public int Heuristic;
}