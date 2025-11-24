using System;
using UnityEngine;

public class ClickManager : MonoBehaviourSingleton<ClickManager>
{
    [SerializeField] private Camera _camera;
    public GameObject ObjectToInstantiate;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           InstantiateOnClick();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            InstantiateOnClick();
        }
    }

    public void InstantiateOnClick()
    {
        Debug.Log("Click");
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            Instantiate(ObjectToInstantiate, hit.point, Quaternion.identity);
        }
    }
}
