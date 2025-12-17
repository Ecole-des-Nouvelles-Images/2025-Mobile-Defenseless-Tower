using UnityEngine;
using EventBus = Utils.EventBus;

namespace Menu
{
    public class PauseButton : MonoBehaviour
    {
        public GameObject PausePanel;

        public void OnPause()
        {
            PausePanel.SetActive(true);
            EventBus.OnGamePaused?.Invoke();
            Debug.Log("OnGame Pause");
        }
    }
}
