using System;
using UnityEngine;

public class ClickManager : MonoBehaviourSingleton<ClickManager>
{
    [SerializeField] private Camera _camera;
    public GameObject ObjectToInstantiate;

    public Vector3 LastPosition;
    
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnClick();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        
        Debug.Log("Click");
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Touche une ray");
            LastPosition = hit.point;
            Debug.Log(hit.collider.name);
            EventBus.OnPlayerClicked?.Invoke();
        }
    }
}
