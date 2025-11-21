using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public int Money;
    
    public List<EnemyStruct> EnemyStructs;

    public EnemyData dataTest;
    private void Start()
    {
        AddEnnemy(dataTest);
    }

    public void AddEnnemy(EnemyData data)
    {
        EnemyStruct newStruct = new EnemyStruct();
        newStruct.Data = data;
        newStruct.SetUpData();
        EnemyStructs.Add(newStruct);
    }
    
    public void UpdateInventory()
    {
        
    }
}
