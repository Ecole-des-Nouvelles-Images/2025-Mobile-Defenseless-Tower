using System;
using UnityEngine;

[Serializable]
public class SpellClass
{
    public Spell SpellData;
    public float Price;

    public void SetData()
    {
        Price = SpellData.Price;
    }

    public void Clear()
    {
        SpellData = null;
        Price = 0;
    }
    
}
