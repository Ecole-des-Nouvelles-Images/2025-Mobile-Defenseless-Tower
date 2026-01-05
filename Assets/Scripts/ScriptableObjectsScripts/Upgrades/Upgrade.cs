using System;
using Player;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;

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
        public LocalizedString LocalizedString;
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
