using System.Collections.Generic;
using Class;
using ScriptableObjectsScripts.Upgrades;
using UnityEngine;
using Utils;

namespace Managers
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private Upgrade _upgradeTest;
        [SerializeField] private GameObject _cardPacker;
        
        [SerializeField] private List<Upgrade> _upgrades = new List<Upgrade>();

        [Header("Number card")] 
        public int CommunCount;
        public int MoyenCount;
        public int RareCount;
        
        private void OnEnable()
        {
            EventBus.OnPlayerTakedCard += HideCard;
        }

        private void OnDisable()
        {
            EventBus.OnPlayerTakedCard -= HideCard;
        }

        
        public void LoadCardProposition()
        {
            for (int i = 0; i < 3; i++)
            { 
                int rand = Random.Range(0, _upgrades.Count);
                Upgrade upgrade = _upgrades[rand];
                Debug.Log(upgrade.name);
                
                
                _cardPacker.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                _cardPacker.transform.GetChild(i).gameObject.GetComponent<Card>().SetUp(upgrade);

                _upgrades.Remove(upgrade);
                
                Debug.Log("00000");
            }
        }
        
        [ContextMenu("LoadProposition")]
        public void LoadListCard()
        {
            _upgrades = UpgradeUtils.GetRandomUpgradeWithRange(CommunCount, MoyenCount, RareCount);
        }
        
        public void HideCard()
        {
            gameObject.SetActive(false);
        }
    }
}
