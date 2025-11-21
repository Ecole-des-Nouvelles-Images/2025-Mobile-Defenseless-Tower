using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int Money;
    
    public List<EnemyClass> EnemyClass;
    public EnemyClass dataTest;

    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject prefabButton;
    private void Start()
    {
        //AddEnnemyToInventory(dataTest);

        Debug.Log(EnemyClass.Count);
        foreach (EnemyClass c in EnemyClass)
        {
            Debug.Log(c.Data.name);
            c.SetUpData();
            AddEnnemyToInventory(c);
        }
    }

    public void AddEnnemyToInventory(EnemyClass classData)
    {
        EnemyClass newClass = new EnemyClass();
        newClass = classData;
        newClass.SetUpData();
        EnemyClass.Add(newClass);
        GameObject instanciate = Instantiate(prefabButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
        instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = classData;
    }
    
    public void UpdateInventory()
    {
        
    }
}
