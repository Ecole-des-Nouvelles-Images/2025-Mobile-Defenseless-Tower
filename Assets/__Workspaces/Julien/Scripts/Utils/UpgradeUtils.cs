using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UpgradeUtils
{
    public static List<Upgrade> GetRandomUpgrade(int number)
    {
        List<Upgrade> upgrades = new List<Upgrade>();
        List<Upgrade> upgradeRessource = Enumerable.ToList(Resources.LoadAll<Upgrade>("Upgrades"));

        for (int i = 0; i < number; i++)
        {
            int[] indexArray = new int[upgradeRessource.Count];
            int randomIndex = Random.Range(0, indexArray.Length);
                
            Upgrade upgrade = upgradeRessource[randomIndex];
            if (upgrades.Contains(upgrade))
            {
                number++;
               continue;
            }
            upgrades.Add(upgrade);
            
        }
        return upgrades;
    }
}
