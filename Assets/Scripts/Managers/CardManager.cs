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
        
            Debug.Log(_upgrades.Count);
            for (int i = 0; i < gameObject.transform.childCount; i++)
            { 
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).gameObject.GetComponent<Card>().SetUp(_upgrades[i]);
            }
        }

        public void HideCard()
        {
            gameObject.SetActive(false);
        }
    }
}
