using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabEnemy;
    [SerializeField] private InventoryHandler _inventory;
    public EnemyData datatest;
    private void Start()
    {
        Spawn(datatest);
    }

     
    [ContextMenu("Spawn")]
    public void Spawn(EnemyData data)
    {
        var enemyStruct = _inventory.EnemyStructs.FirstOrDefault(struc => struc.Data == data);
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
