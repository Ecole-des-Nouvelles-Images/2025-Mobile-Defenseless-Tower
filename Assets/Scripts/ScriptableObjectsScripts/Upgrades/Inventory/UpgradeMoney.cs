using Player;
using UnityEngine;

namespace ScriptableObjectsScripts.Upgrades.Inventory
{
    [CreateAssetMenu(fileName = "Money", menuName = "Scriptable Objects/Upgrade/Money")]
    public class UpgradeMoney : Upgrade
    {
        public int MoneyToAdd;
    
        public override void Apply(InventoryHandler inventary)
        {
            inventary.StartMoney += MoneyToAdd;
        }
    }
}
