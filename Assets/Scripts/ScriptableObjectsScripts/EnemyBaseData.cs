using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName = "EnemyBaseData", menuName = "Scriptable Objects/EnemyBaseData")]
    public class EnemyBaseData : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public int price;
    
        public float Speed;
        public float Health;

        public int NumberToSpawn;
        public int Damage;
        
        [Header("Offset position")] 
        public Vector2 OffsetX;
        public Vector2 OffsetZ;
        public float OffsetUp;

        [Header("Prefab")] 
    
        public GameObject Prefab;
        
        [Header("Sound")]
        public List<AudioClip> SpawnSounds;
        public List<AudioClip> DeadSounds;
    }
}

