using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EventBus.OnGameStart?.Invoke();
    }
}
