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

    [Header("StatBonus")] 
    public float BonusSpeed;
    public float BonusHealth;

    public void SetUpData()
    {
        Name = baseData.Name;
        Sprite = baseData.Sprite;
        price = baseData.price;
        NumberSpawn = baseData.NumberToSpawn;
    }
}
