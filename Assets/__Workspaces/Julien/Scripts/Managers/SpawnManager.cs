using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
{
    [SerializeField] private InventoryHandler _inventory;
    public EnemyClass EnemyClass;
    // private void Start()
    // {
    //     Spawn(EnemyClass);
    // }

     
    [ContextMenu("Spawn")]
    public void Spawn(EnemyClass enemyclass)
    {
        int testMoney = InventoryHandler.Instance.Money - enemyclass.baseData.price;
        if (testMoney < 0) return;
        
        Debug.Log("Spawn");
        var enemyStruct = _inventory.EnemyClass.FirstOrDefault(struc => struc.baseData == enemyclass.baseData);
        Debug.Log(enemyStruct.baseData);

        for (int i = 0; i < enemyStruct.NumberSpawn; i++)
        {
            GameObject instantite = Instantiate(enemyclass.baseData.Prefab);
        }

        InventoryHandler.Instance.Money -= enemyclass.baseData.price;
        EventBus.OnplayerPlaceTroup?.Invoke();
    }
    

    // public IEnumerator Delay()
    // {
    //     
    // }
}
