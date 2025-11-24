using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Upgrade/Enemy")]
public class UpgradeEnemy : Upgrade
{
    public EnemyBaseData TargetData;
    public int NumberToSpawnToAdd;
    
    public override void Apply(InventoryHandler inventary)
    {
        EnemyClass enemyClass = inventary.EnemyClass.FirstOrDefault(struc => struc.baseData == TargetData);
        enemyClass.NumberSpawn += NumberToSpawnToAdd;
    }
}
