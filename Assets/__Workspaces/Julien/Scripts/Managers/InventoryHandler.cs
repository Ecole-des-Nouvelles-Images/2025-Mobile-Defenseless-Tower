using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
{
    public int Money;

    public List<EnemyClass> EnemyClass;
    public EnemyClass dataTest;

    [SerializeField] private GameObject PanelInventoryEnemy;
    [SerializeField] private GameObject prefabButton;

    private void Start()
    {
        List<EnemyClass> copy = new List<EnemyClass>(EnemyClass);
        foreach (EnemyClass c in copy)
        {
            c.SetUpData();
            AddEnnemyToInventory(c);
        }
    }

    public void AddEnnemyToInventory(EnemyClass classData)
    {
        EnemyClass newClass = classData.Clone();
        newClass.SetUpData();
        EnemyClass.Add(newClass);

        GameObject instanciate = Instantiate(prefabButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
        instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = newClass;
    }

    [ContextMenu("Add")]
    // Pour plus tard quand le joueur choisira un sort ou une troupe
    public void AddClass()
    {
        AddEnnemyToInventory(dataTest);
    }
    public void UpdateInventory()
    {
    }
}