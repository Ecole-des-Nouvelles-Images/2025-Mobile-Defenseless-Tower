using System;
using ScriptableObjectsScripts.Spells;

namespace Class
{
    [Serializable]
    public class SpellClass
    {
        public SoSpell SpellData;
        public float Price;
        public float Time;
        public float AreaSize;
        public float Efficiency;
    
        public void SetData()
        {
            Price = SpellData.Price;
            Time = SpellData.Time;
            AreaSize = SpellData.AreaSize;
            Efficiency = SpellData.Efficiency;
        }

        public void Clear()
        {
            SpellData = null;
            Price = 0;
            Time = 0;
        }
    
    }
}
