using System.Linq;
using Player;
using UnityEngine;

namespace ScriptableObjectsScripts.Upgrades.Enemies
{
    [CreateAssetMenu(fileName = "UpgradeSpawn", menuName = "Scriptable Objects/Upgrade/Enemy/NumberSpawn")]
    public class UpgradeEnemySpawnNumber : Upgrade
    {
        public EnemyBaseData TargetData;
        public int NumberToSpawnToAdd;
    
        public override void Apply(InventoryHandler inventary)
        {
            EnemyClass enemyClass = inventary.EnemyClass.FirstOrDefault(struc => struc.baseData == TargetData);
            enemyClass.NumberSpawn += NumberToSpawnToAdd;
        }
    }
}
