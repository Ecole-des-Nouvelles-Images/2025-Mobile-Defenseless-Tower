using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int Money;
    
    public List<EnemyClass> EnemyStructs;
    public EnemyData dataTest;

    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject prefabButton;
    private void Start()
    {
        AddEnnemyToInventory(dataTest);
    }

    public void AddEnnemyToInventory(EnemyData data)
    {
        EnemyClass newClass = new EnemyClass();
        newClass.Data = data;
        newClass.SetUpData();
        EnemyStructs.Add(newClass);
        Instantiate(prefabButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
    }
    
    public void UpdateInventory()
    {
        
    }
}
