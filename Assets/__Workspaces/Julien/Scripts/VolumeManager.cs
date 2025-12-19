using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _sfxVolume;

    [SerializeField] private AudioMixer _audioMixer;
    

    private void OnEnable()
    {
        _musicVolume.value = SaveSound.ValueMusicSlider;
        _sfxVolume.value = SaveSound.ValueSfxSlider;
    }

    private void OnDisable()
    {
        SaveSound.SaveSlideBard(_musicVolume, _sfxVolume);
    }

    public void ChangeSoundEffectVolume()
    {
        _audioMixer.SetFloat("SoundEffect", _sfxVolume.value);
        if (_sfxVolume.value == _sfxVolume.minValue)
        {
            _audioMixer.SetFloat("SoundEffect", -80);
        }
    }

    public void ChangeMusicVolume()
    {
        _audioMixer.SetFloat("Music",  _musicVolume.value);
        if (_musicVolume.value == _musicVolume.minValue)
        {
            _audioMixer.SetFloat("Music", -80);
        }
    }
}

[Serializable]
public static class SaveSound
{
    public static float ValueMusicSlider = -20f;
    public static float ValueSfxSlider = -20f;
    
    public static void SaveSlideBard(Slider music, Slider sfx)
    {
        ValueMusicSlider = music.value;
        ValueSfxSlider = sfx.value;
    }
}
