using System.Collections.Generic;
using System.Linq;
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
        
        [SerializeField] private List<DefenseBaseData> _defenseBaseDatasToSpawn = new List<DefenseBaseData>();
        private int[,] _matrixInt;
        private List<HeuristicResult> _heuristicResults = new List<HeuristicResult>();
        
        private void Awake()
        {
            Money = MaxMoney;
            // foreach (GameObject tower in Towers)
            // {
            //     DefenseBaseDatas.Add(tower.GetComponent<TowerBase>().BaseData);
            // }
            EventBus.OnTerrainGenerate += OnNextLevel;
        }
    
        private void OnDisable()
        {
            EventBus.OnTerrainGenerate -= OnNextLevel;
        }
        
        [ContextMenu("PlaceAITowers")]
        public void PlaceIaTower()
        {
            
            _matrixInt = AiUtils.ConvertMatrixCellToInt(PathManager.Instance.CellsMatrix);
            _heuristicResults = AiUtils.SetHeuristicResult(_matrixInt, DefenseBaseDatas);
            
            _heuristicResults = _heuristicResults.OrderByDescending(heuristic => heuristic.HeuristicValue).ToList();
            for (int i = 0; i < _heuristicResults.Count; i++)
            {
                if (_heuristicResults[i].HeuristicValue > 0)
                {
                    //Debug.Log(_heuristicResults[i].DefenseBaseData.name + " HEURISTIC " + _heuristicResults[i].HeuristicValue);
                }
                else
                {
                    _heuristicResults.RemoveAt(i);
                }
            }
            SetRandomDefenseToSpawn();
            BuyTower();
            Debug.Log(_matrixInt);
        }

        public void SetRandomDefenseToSpawn()
        {
            for (int i = 0; i < _heuristicResults.Count; i++)
            {
                DefenseBaseData defenseBaseData = DefenseBaseDatas[Random.Range(0, DefenseBaseDatas.Count)];
                bool outMoney = CheckIfHeCanBuy(defenseBaseData);
                if (!outMoney) break;
                _defenseBaseDatasToSpawn.Add(defenseBaseData);
            }
        }

        public void BuyTower()
        {
            foreach (DefenseBaseData defense in _defenseBaseDatasToSpawn)
            {
                // je créer une list et je récup que les élément qui sont égal = defense 
                List<HeuristicResult> heuristicResults = _heuristicResults.Where(result => result.DefenseBaseData == defense).ToList();
                // je classe dans l'ordre décroissant par rapport à l'heuristiqueValue
                heuristicResults = heuristicResults.OrderByDescending(result => result.HeuristicValue).ToList();
                
                
                
                if (heuristicResults.Count == 0) continue;
                
                // Faire un random de choix
                int inteligeanceChoice = Random.Range(0, heuristicResults.Count);
                HeuristicResult finalResult = heuristicResults[inteligeanceChoice];

                // ensuite je l'enleve de la list
                _heuristicResults.Remove(finalResult);

                PathManager.Instance.CellsMatrix[Mathf.FloorToInt(finalResult.position.x), Mathf.FloorToInt(finalResult.position.y)].IsTower = true;
                Instantiate(finalResult.DefenseBaseData.Prefab, new Vector3(finalResult.position.x, 0, finalResult.position.y), Quaternion.identity, transform);
            }
            EventBus.OnIaPlaceTower?.Invoke();
        }
        
        
        private bool CheckIfHeCanBuy(DefenseBaseData data)
        {
            int tempMoney = Money - data.Price;
            if (tempMoney < 0)
            {
                return false;
            }
            else
            {
                Money -= data.Price;
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
            _defenseBaseDatasToSpawn.Clear();
            _heuristicResults.Clear();
        }

        public void OnNextLevel()
        {
            RemoveAllTowers();
            MaxMoney += MoneyToAddParLevel;
            Money = MaxMoney;
            PlaceIaTower();
        }
    }
}
