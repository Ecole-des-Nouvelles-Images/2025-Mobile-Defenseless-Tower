using System;
using Player;
using UnityEngine;

namespace ScriptableObjectsScripts.Upgrades
{
    [CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
    public abstract class Upgrade : ScriptableObject
    {
        [Header("Visuel")] 
        public string Name;
        public Sprite Srite;
        [TextArea] public string Description;
    
    
        public abstract void Apply(InventoryHandler inventary);
    }
}
