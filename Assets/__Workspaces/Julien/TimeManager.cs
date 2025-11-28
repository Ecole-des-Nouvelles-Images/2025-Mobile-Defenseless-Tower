using System;
using UnityEngine;
using Utils;

public class TimeManager : MonoBehaviourSingleton<TimeManager>
{
    [Header("Chronometre")] 
        
    public bool GameIsPlaying;
    public float MaxChrono;
    public float CurrentChrono;

    private void OnEnable()
    {
        EventBus.OnplayerPlaceTroup += StartChrono;
        EventBus.OnGamePaused += StopChrono;
        EventBus.OnGameResume += ResumeChrono;
    }

    private void OnDisable()
    {
        EventBus.OnplayerPlaceTroup -= StartChrono;
        EventBus.OnGamePaused -= StopChrono;
        EventBus.OnGameResume -= ResumeChrono;
    }

    private void Update()
    {
        if (GameIsPlaying)
        {
            CurrentChrono -= Time.deltaTime;
        }

        if (CurrentChrono <= 0)
        {
            ChronoIsFinished();
        }
    }

    public void StartChrono()
    {
        CurrentChrono = MaxChrono;
        GameIsPlaying = true;
    }

    public void ResumeChrono()
    {
        GameIsPlaying = true;
    }
    
    public void StopChrono()
    {
        GameIsPlaying = false;
    }

    public void ChronoIsFinished()
    {
        EventBus.OnChronoAreFinished?.Invoke();
        Debug.Log("Le jeu est fini");
        // Pensez à faire un panel de fin le load scene à la rache est temporaire.
    }
}
