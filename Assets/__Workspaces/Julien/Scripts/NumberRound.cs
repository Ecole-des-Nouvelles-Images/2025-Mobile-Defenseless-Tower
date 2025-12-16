using System;
using Managers;
using TMPro;
using UnityEngine;
using Utils;

public class NumberRound : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private void OnEnable()
    {
        EventBus.OnIaPlaceTower += ChangeText;
    }

    private void OnDisable()
    {
        EventBus.OnIaPlaceTower -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = DifficultyManager.Instance.CurrentLevel.ToString();
    }
}
