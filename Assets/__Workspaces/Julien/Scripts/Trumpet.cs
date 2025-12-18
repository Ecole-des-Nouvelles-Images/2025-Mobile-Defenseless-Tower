using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Trumpet : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public List<AudioClip> AudioClip;

    private void OnEnable()
    {
        ParticleSystem.Play();
        SoundManager.Instance.PlayRandomSound(AudioClip, gameObject);
    }
}
