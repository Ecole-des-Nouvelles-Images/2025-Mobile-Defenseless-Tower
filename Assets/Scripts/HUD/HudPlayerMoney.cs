using Player;
using TMPro;
using UnityEngine;
using Utils;

namespace HUD
{
    public class HudPlayerMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMoney;
    
        private void OnEnable()
        {
            _textMoney.text = InventoryHandler.Instance.Money.ToString();
            EventBus.OnPlayerUseMoney += UpdateMoney;
            EventBus.OnInventoryAreUpdated += UpdateMoney;
        }
        private void OnDisable()
        {
            EventBus.OnPlayerUseMoney -= UpdateMoney;
            EventBus.OnInventoryAreUpdated -= UpdateMoney;
        }

        public void UpdateMoney()
        {
            _textMoney.text = InventoryHandler.Instance.Money.ToString();
        }
    }
}
