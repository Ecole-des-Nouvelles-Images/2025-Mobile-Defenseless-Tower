using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int StartMoney;
    public int Money;

    public SpellClass EquipedSpell;
    
    public List<EnemyClass> EnemyClass = new List<EnemyClass>();
    public List<SpellClass> SpellClasses = new List<SpellClass>();
    
    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject PanelInventorySpell;
    [SerializeField] private GameObject prefabEnemyButton;
    [SerializeField] private GameObject prefabSpellButton;

    public Upgrade UpgradeTest;

    private void OnEnable()
    {
        EventBus.OnNextLevel += UpdateInventoryData;
        EventBus.OnPlayerClicked += DropSpell;
    }

    private void OnDestroy()
    {
        EventBus.OnNextLevel -= UpdateInventoryData;
        EventBus.OnPlayerClicked -= DropSpell;
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
        
        foreach (SpellClass c in SpellClasses)
        {
            c.SetData();
        }
        
        foreach (SpellClass c in SpellClasses)
        {
            SetVisuelSpell(c);
        }
    }

    
    // Enemy
    public void AddEnemy(EnemyClass classToAdd)
    {
        EnemyClass.Add(classToAdd);
        SetVisualEnemy(classToAdd);
    }
    public void SetVisualEnemy(EnemyClass enemyClass)
    {
        GameObject instanciate = Instantiate(prefabEnemyButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
        instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = enemyClass;
    }
    
    // Sort
    public void EquipeSpell(SpellClass spellClass)
    {
        EquipedSpell = spellClass;
    }
    public void DropSpell()
    {
        if (EquipedSpell.SpellData == true)
        {
            Instantiate(EquipedSpell.SpellData.Prefab, ClickManager.Instance.LastPosition, Quaternion.identity);
        }
    }
    public void UnEquipSpell()
    {
        EquipedSpell = null;
        Debug.Log("Unequipped spell");
    }
    public void SetVisuelSpell(SpellClass spellClass)
    {
        GameObject instanciate = Instantiate(prefabSpellButton, transform.position, quaternion.identity, PanelInventorySpell.transform);
        instanciate.GetComponent<SpellButton>().SpellClass = spellClass;
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