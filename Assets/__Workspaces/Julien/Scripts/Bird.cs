using UnityEngine;

public class Bird : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("grougrou");
    }
}
