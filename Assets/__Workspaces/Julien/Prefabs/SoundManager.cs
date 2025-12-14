using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Utils;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    public GameObject PrefabSound;
    
    [Header("Enemie--------------------------------------------")]
    [Header("Chevalier")]
    public List<AudioClip> ChevalierSpawn;
    [Header("Golem")]
    public List<AudioClip> GolemSpawn;
    
    [Header("Spell--------------------------------------------")]
    [Header("Freez")]
    public List<AudioClip> FreezSpawn;
    [Header("Health")]
    public List<AudioClip> HealthSpawn;
    
    [Header("Tower--------------------------------------------")]
    [Header("Shoot")]
    public List<AudioClip> CanonShoot;
    public List<AudioClip> ArbeletteShoot;
    public List<AudioClip> CatapultShoot;
    public void PlayRandomSound(List<AudioClip> audioClip, GameObject target)
    {
        AudioClip audio = audioClip[Random.Range(0, audioClip.Count)];
        GameObject prefabSound = Instantiate(PrefabSound,target.transform.position, Quaternion.identity);
        prefabSound.GetComponent<AudioSource>().clip = audio;
        prefabSound.GetComponent<AudioSource>().Play();
    }

    public void PlaySound(AudioClip audioClip, GameObject target)
    {
        GameObject prefabSound = Instantiate(PrefabSound,target.transform.position, Quaternion.identity);
        prefabSound.GetComponent<AudioSource>().clip = audioClip;
        prefabSound.GetComponent<AudioSource>().Play();
    }
    
    public AudioClip GetSound(List<AudioClip> audioClip)
    {
       return audioClip[Random.Range(0, audioClip.Count)];
    }
}
