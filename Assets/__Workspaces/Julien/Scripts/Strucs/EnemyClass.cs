using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class EnemyClass
{
    [FormerlySerializedAs("Data")] public EnemyBaseData baseData;

    public string Name;
    public Sprite Sprite;
    public int price;
    public int NumberSpawn;

    public void SetUpData()
    {
        Name = baseData.Name;
        Sprite = baseData.Sprite;
        price = baseData.price;
        NumberSpawn = baseData.NumberToSpawn;
    }

    public EnemyClass Clone()
    {
        return new EnemyClass
        {
            baseData = this.baseData,
            Name = this.Name,
            Sprite = this.Sprite,
            price = this.price,
            NumberSpawn = this.NumberSpawn
        };
    }
}
