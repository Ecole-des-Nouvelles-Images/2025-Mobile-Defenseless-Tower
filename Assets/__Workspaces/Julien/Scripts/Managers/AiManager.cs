using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiManager : MonoBehaviour
{
    public int MaxMoney;
    public int Money;

    public List<GameObject> Towers;

    private void OnEnable()
    {
        EventBus.OnTerrainGenerate += PlaceTowers;
    }

    private void OnDisable()
    {
        EventBus.OnTerrainGenerate -= PlaceTowers;
    }

    private void Start()
    {
        Money = MaxMoney;
    }
    
    [ContextMenu("PlaceTowers")]
    public void PlaceTowers()
    {
        int safety = 0;          // compteur de sécurité
        int maxSafety = 500;     // valeur max avant arrêt forcé

        while (Money > 0)
        {
            ChoiceRandomPos();

            safety++;
            if (safety > maxSafety)
            {
                Debug.LogWarning("PlaceTowers STOP → boucle trop longue, arrêt de sécurité !");
                break;
            }
        }
    }
    
    [ContextMenu("RandPos")]
    public void ChoiceRandomPos()
    {
        int x = Random.Range(0, PathManager.Instance.Width);
        int z = Random.Range(0, PathManager.Instance.Height);

        var cell = PathManager.Instance.CellsMatrix[x, z];

        if (cell == null)
        {
            Debug.LogError("CellMatrix["+x+","+z+"] est NULL !");
            return;
        }

        if (!cell.IsAPath && !cell.IsTower)
        {
            GameObject tower = ChoiceRandDefense();
            if (CheckIfHeCanBuy(tower))
            {
                Instantiate(tower, new Vector3(x, 0, z), Quaternion.identity, transform);
                cell.IsTower = true;
            }
        }
    }
    
    public GameObject ChoiceRandDefense()
    {
        int rand = Random.Range(0, Towers.Count);
        Debug.Log(Towers[rand].name);
        return Towers[rand];
    }

    private bool CheckIfHeCanBuy(GameObject tower)
    {
        int tempMoney = Money - tower.GetComponent<TowerBase>().BaseData.Price;
        if (tempMoney < 0)
        {
            return false;
        }
        else
        {
            Money -= tower.GetComponent<TowerBase>().BaseData.Price;
            return true;
        }
    }

    [ContextMenu("RemoveAllTowers")]
    public void RemoveAllTowers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
