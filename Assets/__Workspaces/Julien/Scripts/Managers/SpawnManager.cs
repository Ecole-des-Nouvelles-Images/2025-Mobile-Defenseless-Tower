using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
{
    public GameObject prefabEnemy;
    [SerializeField] private InventoryHandler _inventory;
    public EnemyClass EnemyClass;
    // private void Start()
    // {
    //     Spawn(EnemyClass);
    // }

     
    [ContextMenu("Spawn")]
    public void Spawn(EnemyClass enemyclass)
    {
        Debug.Log("Spawn");
        var enemyStruct = _inventory.EnemyStructs.FirstOrDefault(struc => struc.Data == enemyclass.Data);
        Debug.Log(enemyStruct.Data);

        for (int i = 0; i < enemyStruct.NumberSpawn; i++)
        {
            GameObject instantite = Instantiate(prefabEnemy);
            Debug.Log(i);
        }
    }
    

    // public IEnumerator Delay()
    // {
    //     
    // }
}
