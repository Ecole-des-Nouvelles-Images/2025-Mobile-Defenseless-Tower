using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeHealth", menuName = "Scriptable Objects/Upgrade/Enemy/MaxHealth")]
public class UpgradeEnemyMaxHealth : Upgrade
{
    public EnemyBaseData TargetData;
    public int HealthToAdd;
    
    public override void Apply(InventoryHandler inventary)
    {
        EnemyClass enemyClass = inventary.EnemyClass.FirstOrDefault(struc => struc.baseData == TargetData);
        enemyClass.MaxHealth += HealthToAdd;
    }
}
