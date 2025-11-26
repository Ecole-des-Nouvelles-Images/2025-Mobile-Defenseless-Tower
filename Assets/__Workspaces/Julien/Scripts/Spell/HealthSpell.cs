using System;
using UnityEngine;

public class HealthSpell : Spell
{
    public float MaxTimeBeforHealth;
    public float TimeBeforHeal;
    public float HealthParTick;
    
    private void Update()
    {
        TimeBeforHeal += Time.deltaTime;
        if (TimeBeforHeal > MaxTimeBeforHealth)
        {
            TimeBeforHeal = 0;
            DoSpell();
        }
    }

    public override void DoSpell()
    {
        
    }
}
