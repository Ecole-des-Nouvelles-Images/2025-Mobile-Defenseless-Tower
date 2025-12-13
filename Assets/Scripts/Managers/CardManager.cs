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

        
        [SerializeField] private GameObject _cardPacker;
        
        [SerializeField] private List<Upgrade> _upgrades = new List<Upgrade>();
        [SerializeField] private List<Upgrade> _upgradeToGive = new List<Upgrade>();

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
            if (_upgrades.Count <= 0) LoadListCard();
            _upgradeToGive = UpgradeUtils.ChoiceThreeRandomCardFromList(_upgrades);

            for (int i = 0; i < 3; i++)
            {
                _cardPacker.transform.GetChild(i).gameObject.SetActive(true);
                _cardPacker.transform.GetChild(i).GetComponent<Card>().SetUp(_upgradeToGive[i]);
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
