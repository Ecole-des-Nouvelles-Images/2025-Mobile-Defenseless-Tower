using System;
using ScriptableObjectsScripts;

namespace Structs
{
    [Serializable]
    public class EnemyClass
    {
        public EnemyBaseData baseData;

        public string Name;
        public int price;
        public int NumberSpawn;

        public float Speed;
        public float MaxHealth;
        public int Damage;
        public void SetUpData()
        {
            Name = baseData.Name;
            price = baseData.price;
            NumberSpawn = baseData.NumberToSpawn;
            Speed = baseData.Speed;
            MaxHealth = baseData.Health;
            Damage = baseData.Damage;
        }
    }
}
