using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Managers
{
    public class SoundManager : MonoBehaviourSingleton<SoundManager>
    {
        public GameObject PrefabSound;
        
        public void PlayRandomSound(List<AudioClip> audioClip, GameObject target, bool randomPitch = false)
        {
            AudioClip audio = audioClip[Random.Range(0, audioClip.Count)];
            GameObject prefabSound = Instantiate(PrefabSound,target.transform.position, Quaternion.identity);
            prefabSound.GetComponent<AudioSource>().clip = audio;
            prefabSound.GetComponent<AudioSource>().Play();

            if (randomPitch)
            {
                float randPitch = Random.Range(1, 1.3f);
                prefabSound.GetComponent<AudioSource>().pitch = randPitch;
            }
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
}
