using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int StartMoney;
    public int Money;

    public List<EnemyClass> EnemyClass;

    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject prefabButton;

    public Upgrade UpgradeTest;

    private void OnEnable()
    {
        EventBus.OnNextLevel += UpdateInventoryData;
    }

    private void OnDestroy()
    {
        EventBus.OnNextLevel -= UpdateInventoryData;
    }

    private void Start()
    {
        foreach (EnemyClass c in EnemyClass)
        {
            c.SetUpData();
        }
        
        foreach (EnemyClass c in EnemyClass)
        {
            SetVisualEnemy(c);
        }
    }

    
    // Enemy
    public void AddEnemy(EnemyClass classToAdd)
    {
        EnemyClass.Add(classToAdd);
        SetVisualEnemy(classToAdd);
    }
    public void SetVisualEnemy(EnemyClass classToAdd)
    {
        GameObject instanciate = Instantiate(prefabButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
        instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = classToAdd;
    }
    
    // Sort
    public void AddSpell()
    {
        
    }
    public void SetVisualSpell()
    {
        
    }
    
    
    public void UpdateInventoryData()
    {
        Debug.Log("SetInventory money");
        Money = StartMoney;
        EventBus.OnInventoryAreUpdated?.Invoke();
    }
    [ContextMenu("Upgrade")]
    public void Upgrade()
    {
        UpgradeTest.Apply(this);
    }

    
}