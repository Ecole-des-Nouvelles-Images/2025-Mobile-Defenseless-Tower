using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviourSingleton<ClickManager>
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private LayerMask _layerMask;
    
    public Vector3 LastPosition;
    private InputAction tab;

    private void OnEnable()
    {
        _playerInput.actions["PcClick"].started += GetPCClick;
        _playerInput.actions["FirstTouch"].started += GetFirstTouch;
    }
    
    private void OnDisable()
    {
        _playerInput.actions["PcClick"].started -= GetPCClick;
        _playerInput.actions["FirstTouch"].started -= GetFirstTouch;
    }

    private void GetPCClick(InputAction.CallbackContext obj)
    {
        OnClicked(Mouse.current.position.ReadValue());
    }

    private void GetFirstTouch(InputAction.CallbackContext obj) 
    {
        OnClicked(Input.mousePosition);
    }
    
    private void OnClicked(Vector2 clickPos)
    {
        Debug.Log("Click");
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
        if (Physics.Raycast(ray, out hit,Mathf.Infinity, _layerMask )) 
        {
            Debug.Log("Touche une ray");
            LastPosition = hit.point;
            EventBus.OnPlayerClicked?.Invoke();
            
        }
    }
}
