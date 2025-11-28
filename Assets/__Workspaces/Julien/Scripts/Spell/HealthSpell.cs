using System;
using System.Collections.Generic;
using Class;
using UnityEngine;

public class HealthSpell : Spell
{
    public float MaxTimeBeforHealth;
    public float TimeBeforHeal;
    public float HealthParTick;

    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    private void Update()
    {
        TimeBeforHeal += Time.deltaTime;
        if (TimeBeforHeal > MaxTimeBeforHealth)
        {
            TimeBeforHeal = 0;
            DoSpell();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Add(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }

    public override void SetUp()
    {
        throw new NotImplementedException();
    }

    public override void DoSpell()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.GetComponent<IHealable>().GetHealth(HealthParTick);
        }
    }
}
