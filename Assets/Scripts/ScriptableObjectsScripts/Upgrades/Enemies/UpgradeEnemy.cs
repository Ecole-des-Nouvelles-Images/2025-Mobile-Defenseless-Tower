using System.Linq;
using Player;
using ScriptableObjectsScripts;
using ScriptableObjectsScripts.Upgrades;
using Structs;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeEnemy", menuName = "Scriptable Objects/Upgrade/Enemy")]
public class UpgradeEnemy : Upgrade
{
    public EnemyBaseData TargetData;

    public int PriceToAdd;
    public int HealthToAdd;
    public int NumberToSpawnToAdd;
    public float SpeedToAdd;
    
    public override void Apply(InventoryHandler inventary)
    {
        EnemyClass enemyClass = inventary.EnemyClass.FirstOrDefault(struc => struc.baseData == TargetData);
        enemyClass.MaxHealth += HealthToAdd;
        enemyClass.price += PriceToAdd;
        enemyClass.NumberSpawn += NumberToSpawnToAdd;
        enemyClass.Speed += SpeedToAdd;
    }
}
