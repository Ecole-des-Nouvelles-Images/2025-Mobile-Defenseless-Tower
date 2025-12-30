using System;
using System.Collections.Generic;
using System.Linq;
using Class;
using ScriptableObjectsScripts.Upgrades;
using UnityEngine;
using Utils;

namespace Managers
{
    public class CardManager : MonoBehaviourSingleton<CardManager>
    {
        [SerializeField] private GameObject _cardPrefab;

        
        [SerializeField] private GameObject _cardPacker;

        [SerializeField] private List<Upgrade> _avaibleUpgrades = new List<Upgrade>();
        [SerializeField] private List<Upgrade> _upgrades = new List<Upgrade>();
        [SerializeField] private List<Upgrade> _upgradeToGive = new List<Upgrade>();

        
        
        [Header("Number card")] 
        public int CommunCount;
        public int MoyenCount;
        public int RareCount;

        [SerializeField] private string _path;

        private void Awake()
        {
            LoadAvaibleUpgrades();
        }

        private void OnEnable()
        {
            EventBus.OnPlayerTakedCard += HideCard;
        }

        private void OnDisable()
        {
            EventBus.OnPlayerTakedCard -= HideCard;
        }

        public void LoadAvaibleUpgrades()
        {
            _avaibleUpgrades = Enumerable.ToList(Resources.LoadAll<Upgrade>(_path));
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
            _upgrades = UpgradeUtils.GetRandomUpgradeWithRange(CommunCount, MoyenCount, RareCount, _avaibleUpgrades);
        }
        
        public void HideCard()
        {
            gameObject.SetActive(false);
        }

        public void AddUpgrades(List<Upgrade> upgrades)
        {
            foreach (Upgrade up in upgrades)
            {
                _avaibleUpgrades.Add(up);
            }
        }

        public void RemoveUpgrade(Upgrade upgrade)
        {
            _avaibleUpgrades.Remove(upgrade);
        }
    }
}
