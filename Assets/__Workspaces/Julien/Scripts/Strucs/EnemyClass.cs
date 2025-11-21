using System;
using UnityEngine;

[Serializable]
public class EnemyClass
{
    public EnemyData Data;

    public string Name;
    public Sprite Sprite;
    public int price;
    
    public int NumberSpawn;
    
    public void SetUpData()
    {
        Name = Data.Name;
        Sprite = Data.Sprite;
        price = Data.price;
        NumberSpawn = Data.NumberToSpawn;
    }
}
