using UnityEngine;
using Utils;

public class Flag : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _captured;
    
    private void OnEnable()
    {
        EventBus.OnLevelFinished += CaptureFlag;
    }

    private void OnDisable()
    {
        EventBus.OnLevelFinished -= CaptureFlag;
    }

    private void CaptureFlag()
    {
        Debug.Log("Flag captured");
    }
}
