using System.Linq;
using Class;
using Player;
using ScriptableObjectsScripts.Spells;
using ScriptableObjectsScripts.Upgrades;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSpell", menuName = "Scriptable Objects/Upgrade/Spell")]
public class UpgradeSpell : Upgrade
{
    public SoSpell TargetSpell;
    
    public int CostToAdd;
    public float TimeToAdd;
    public float SizeToAdd;
    public float HealToAdd;
    public override void Apply(InventoryHandler inventary)
    {
        SpellClass spell = inventary.SpellClasses.FirstOrDefault(struc => struc.SpellData == TargetSpell);
        spell.Price += CostToAdd;
        spell.Time += TimeToAdd;
        spell.AreaSize += SizeToAdd;
        spell.Efficiency += HealToAdd;
    }
}
