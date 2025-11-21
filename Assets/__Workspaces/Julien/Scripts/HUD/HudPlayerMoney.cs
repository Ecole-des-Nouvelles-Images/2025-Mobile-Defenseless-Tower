using System;
using TMPro;
using UnityEngine;

public class HudPlayerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    
    private void OnEnable()
    {
        _textMoney.text = InventoryHandler.Instance.Money.ToString();
        EventBus.OnplayerPlaceTroup += UpdateMoney;
    }
    private void OnDisable()
    {
        EventBus.OnplayerPlaceTroup -= UpdateMoney;
    }

    public void UpdateMoney()
    {
        _textMoney.text = InventoryHandler.Instance.Money.ToString();
    }
}
