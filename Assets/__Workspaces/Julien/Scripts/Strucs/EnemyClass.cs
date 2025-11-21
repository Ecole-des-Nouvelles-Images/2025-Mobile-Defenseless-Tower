using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class EnemyClass
{
    public EnemyData Data;

    public string Name;
    public Sprite Sprite;
    public int price;
    
    public int NumberSpawn;
    
    public void SetUpData(EnemyData data)
    {
        Data = data;
        Name = Data.Name;
        Sprite = Data.Sprite;
        price = Data.price;
        NumberSpawn = Data.NumberToSpawn;
    }
}
