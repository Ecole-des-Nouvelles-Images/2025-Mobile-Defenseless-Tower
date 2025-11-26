using System;
using UnityEngine;

[Serializable]
public class SpellClass
{
    public SoSpell SpellData;
    public float Price;
    public float Time;
    public float AreaSize;
    
    public void SetData()
    {
        Price = SpellData.Price;
        Time = SpellData.Time;
        AreaSize = SpellData.AreaSize;
    }

    public void Clear()
    {
        SpellData = null;
        Price = 0;
        Time = 0;
    }
    
}
