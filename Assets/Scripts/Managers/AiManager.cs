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

        //public List<GameObject> Towers;
        public List<DefenseBaseData> DefenseBaseDatas = new List<DefenseBaseData>();

        private int[,] _matrixInt;
        public List<HeuristicResult> _heuristicResults = new List<HeuristicResult>();
        
        private void Awake()
        {
            Money = MaxMoney;
            // foreach (GameObject tower in Towers)
            // {
            //     DefenseBaseDatas.Add(tower.GetComponent<TowerBase>().BaseData);
            // }
            //EventBus.OnTerrainGenerate += PlaceTowers;
            EventBus.OnNextLevel += OnNextLevel;
        }
    
        private void OnDisable()
        {
            //EventBus.OnTerrainGenerate -= PlaceTowers;
            EventBus.OnNextLevel -= OnNextLevel;
        }

        [ContextMenu("PlaceTowers")]
        public void PlaceIaTower()
        {
            _matrixInt = AiUtils.ConvertMatrixCellToInt(PathManager.Instance.CellsMatrix);
            _heuristicResults = AiUtils.SetHeuristicResult(_matrixInt, DefenseBaseDatas);
            for (int i = 0; i < _heuristicResults.Count; i++)
            {
                if (_heuristicResults[i].HeuristicValue > 0)
                {
                    Debug.Log(_heuristicResults[i].DefenseBaseData.name);
                    Instantiate(_heuristicResults[i].DefenseBaseData.Prefab.gameObject, new Vector3(_heuristicResults[i].position.x,0,_heuristicResults[i].position.y), Quaternion.identity);
                }
            }
            
            Debug.Log(_matrixInt);
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
    }
}
