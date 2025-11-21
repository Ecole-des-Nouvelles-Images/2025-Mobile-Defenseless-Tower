using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int Money;
    
    public List<EnemyClass> EnemyStructs;
    public EnemyClass dataTest;

    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject prefabButton;
    private void Start()
    {
        dataTest.SetUpData();
        //AddEnnemyToInventory(dataTest);

        foreach (EnemyClass c in EnemyStructs)
        {
            c.SetUpData();
            AddEnnemyToInventory(c);
        }
    }

    public void AddEnnemyToInventory(EnemyClass classData)
    {
        EnemyClass newClass = new EnemyClass();
        newClass = classData;
        newClass.SetUpData();
        EnemyStructs.Add(newClass);
        GameObject instanciate = Instantiate(prefabButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
        instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = classData;
    }
    
    public void UpdateInventory()
    {
        
    }
}
