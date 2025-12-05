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
        
        private List<Upgrade> _upgrades = new List<Upgrade>();
    
        private void OnEnable()
        {
            EventBus.OnPlayerTakedCard += HideCard;
        }

        private void OnDisable()
        {
            EventBus.OnPlayerTakedCard -= HideCard;
        }

        [ContextMenu("LoadProposition")]
        public void LoadCardProposition()
        {
            _upgrades = UpgradeUtils.GetRandomUpgrade(GameManager.Instance.NumberCard);
        
            for (int i = 0; i < _cardPacker.gameObject.transform.childCount; i++)
            { 
                _cardPacker.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                _cardPacker.transform.GetChild(i).gameObject.GetComponent<Card>().SetUp(_upgrades[i]);
            }
        }

        public void HideCard()
        {
            gameObject.SetActive(false);
        }
    }
}
