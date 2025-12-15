using System;
using UnityEngine;

public class DestroyGameobjectAfeterSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _time;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _time = _audioSource.time;
        _audioSource.Play();
        //Destroy(gameObject, _time);
    }
}
