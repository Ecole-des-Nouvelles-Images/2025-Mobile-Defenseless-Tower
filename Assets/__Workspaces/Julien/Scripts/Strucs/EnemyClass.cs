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

    public EnemyClass Clone()
    {
        return new EnemyClass
        {
            Data = this.Data,
            Name = this.Name,
            Sprite = this.Sprite,
            price = this.price,
            NumberSpawn = this.NumberSpawn
        };
    }
}
