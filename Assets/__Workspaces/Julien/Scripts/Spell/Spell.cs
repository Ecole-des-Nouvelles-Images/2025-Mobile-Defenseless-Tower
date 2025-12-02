using System;
using Class;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public  SpellClass SpellClass;

    private void Start()
    {
        Destroy(gameObject, SpellClass.Time);
        transform.localScale = new Vector3(SpellClass.AreaSize, SpellClass.AreaSize, SpellClass.AreaSize);
    }
    
    public abstract void DoSpell();
}
