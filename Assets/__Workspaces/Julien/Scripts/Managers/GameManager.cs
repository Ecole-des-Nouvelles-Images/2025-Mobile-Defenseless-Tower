using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SplineManager _splineManager;
    private void OnEnable()
    {
        EventBus.OnLevelFinished += LoadNewLevel;
    }
    
    private void OnDisable()
    {
        EventBus.OnLevelFinished -= LoadNewLevel;
    }

    private void Start()
    {
        EventBus.OnGameStart?.Invoke();
    }

    public void LoadNewLevel()
    {
        _splineManager.GenerateSpline();
        EventBus.OnNextLevel?.Invoke();
    }
}
