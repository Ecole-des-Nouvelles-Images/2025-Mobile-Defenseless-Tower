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
        public Rarity Rarity;
        
        
        [TextArea] public string Description;
        
        public virtual void Apply(InventoryHandler inventary)
        {
            // Cette methode est jouer dans les type "Upgrade"
            
        }
    }
}

[Serializable]
public enum Rarity
{
    Commun = 0,
    Moyen = 1,
    Rare = 2
}
