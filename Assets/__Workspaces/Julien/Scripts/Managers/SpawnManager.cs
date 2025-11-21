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
        int testMoney = InventoryHandler.Instance.Money - enemyclass.Data.price;
        if (testMoney < 0) return;
        
        Debug.Log("Spawn");
        var enemyStruct = _inventory.EnemyClass.FirstOrDefault(struc => struc.Data == enemyclass.Data);
        Debug.Log(enemyStruct.Data);

        for (int i = 0; i < enemyStruct.NumberSpawn; i++)
        {
            GameObject instantite = Instantiate(enemyclass.Data.Prefab);
        }

        InventoryHandler.Instance.Money -= enemyclass.Data.price;
        EventBus.OnplayerPlaceTroup?.Invoke();
    }
    

    // public IEnumerator Delay()
    // {
    //     
    // }
}
