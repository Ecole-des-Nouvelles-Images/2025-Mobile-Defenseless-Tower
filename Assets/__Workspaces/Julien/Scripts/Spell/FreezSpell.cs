using System;
using System.Collections.Generic;
using UnityEngine;

public class FreezSpell : Spell
{
    [SerializeField] private List<GameObject> _targets;
    
    public override void SetUp()
    {
        throw new NotImplementedException();
    }

    public override void DoSpell()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if (InPause) return;
        TimeSpell -= Time.deltaTime;
        
        if (TimeSpell <= 0) UnfreeAll();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            other.GetComponent<IFreezable>().Freeze();
            _targets.Add(other.gameObject);
        }
    }

    private void UnfreeAll()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            _targets[i].GetComponent<IFreezable>().Unfreeze();
        }
        Destroy(gameObject);
    }
}
