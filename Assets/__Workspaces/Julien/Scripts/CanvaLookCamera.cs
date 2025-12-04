using System;
using UnityEngine;

public class CanvaLookCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    private void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        Vector3 camForward = _camera.transform.forward;
        Vector3 camUp = _camera.transform.up;

        transform.LookAt(transform.position + camForward, camUp);
    }
}
