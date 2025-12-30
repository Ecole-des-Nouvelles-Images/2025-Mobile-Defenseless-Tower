using System.Collections.Generic;
using Class;
using Managers;
using Player;
using UnityEngine;
using Utils;

public class EnemyWitch : Enemy
{
    [Header("Only Witch")] 
    [SerializeField] private GameObject Visuel;

    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private InventoryHandler _inventory;
    
    public override void Start()
    {
        base.Start();
        _inventory = GameObject.Find("InventoryHandler").GetComponent<InventoryHandler>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        EventBus.OnEnemyDie += RefoundMoney;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventBus.OnEnemyDie -= RefoundMoney;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemies.Add(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void RefoundMoney(Enemy enemy)
    {
        float refoundedPrice = enemy.EnemyClass.price * 0.50f;
        refoundedPrice = Mathf.RoundToInt(refoundedPrice);
        _inventory.Money += refoundedPrice;
        SpawnManager.Instance.SpawnTextInWorldPosition(refoundedPrice.ToString(), Color.yellow, enemy.gameObject.transform.position);
    }
}
