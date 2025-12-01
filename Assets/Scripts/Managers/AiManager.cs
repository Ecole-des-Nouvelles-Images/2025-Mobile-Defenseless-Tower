using System.Collections.Generic;
using Class;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Managers
{
    public class AiManager : MonoBehaviourSingleton<AiManager>
    {
        public int MoneyToAddParLevel;
    
        public int MaxMoney;
        public int Money;

        public List<GameObject> Towers;

        private void Awake()
        {
            Money = MaxMoney;
            EventBus.OnTerrainGenerate += PlaceTowers;
            EventBus.OnNextLevel += OnNextLevel;
        }
    
        private void OnDisable()
        {
            EventBus.OnTerrainGenerate -= PlaceTowers;
            EventBus.OnNextLevel -= OnNextLevel;
        }
    
        [ContextMenu("PlaceTowers")]
        public void PlaceTowers()
        {
            while (Money > 0)
            {
                ChoiseBestPos();
            }
            
            EventBus.OnIaPlaceTower?.Invoke();
        }
    

        private void ChoiseBestPos()
        {
            
        }
        
        
        
        
        
        public GameObject ChoiceRandDefense()
        {
            int rand = Random.Range(0, Towers.Count);
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
                Vector3 pos = transform.GetChild(i).transform.position;
                PathManager.Instance.CellsMatrix[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.z)].IsTower = false;
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        public void OnNextLevel()
        {
            MaxMoney += MoneyToAddParLevel;
            Money = MaxMoney;
        
            RemoveAllTowers();
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
            else
            {
                ChoiceRandomPos();
            }
        }
    }
}
