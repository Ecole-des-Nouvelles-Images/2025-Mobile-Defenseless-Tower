using System.Collections.Generic;
using Managers;
using UnityEngine;
using EventBus = Utils.EventBus;

public class Trumpet : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public List<AudioClip> TrumpetSfx;
    public List<AudioClip> Confetti;

    public float Time;

    private bool _playedSound = false;
    private void OnEnable()
    {
        SoundManager.Instance.PlayRandomSound(TrumpetSfx, gameObject);
        Time = TrumpetSfx[0].length;
    }

    private void Update()
    {
        Time -= UnityEngine.Time.deltaTime;
        if (Time <= 0 && !_playedSound)
        {
            _playedSound = true;
            EventBus.OnConfettiPlayed?.Invoke();
            ParticleSystem.Play();
            SoundManager.Instance.PlayRandomSound(Confetti, gameObject);
        }
    }
}
