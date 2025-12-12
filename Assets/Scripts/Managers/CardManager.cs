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
            List<Upgrade> upgrades = new List<Upgrade>();
            upgrades = UpgradeUtils.ChoiceThreeRandomCardFromList(_upgrades);
        
            for (int i = 0; i < _cardPacker.gameObject.transform.childCount; i++)
            { 
                _cardPacker.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                _cardPacker.transform.GetChild(i).gameObject.GetComponent<Card>().SetUp(upgrades[i]);
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
