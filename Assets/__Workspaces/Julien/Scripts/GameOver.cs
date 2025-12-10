using System;
using UnityEngine;
using Utils;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    
    private void OnEnable()
    {
        EventBus.OnChronoAreFinished += OpenPanel;
    }

    private void OnDisable()
    {
        EventBus.OnChronoAreFinished -= OpenPanel;
    }

    private void OpenPanel()
    {
        _endPanel.SetActive(true);
        EventBus.OnGamePaused.Invoke();
    }
}
