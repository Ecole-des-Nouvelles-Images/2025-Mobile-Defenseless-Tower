using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsScripts.Spells
{
    [CreateAssetMenu(fileName = "Speel", menuName = "Scriptable Objects/Speel")]
    public class SoSpell : ScriptableObject
    {
        public Sprite Sprite;
        public int Price;
        public float Time;
        public float AreaSize;
        public float Efficiency;
        
        public GameObject Prefab;
        
        public List<AudioClip> SpawnSounds;
    }
}
