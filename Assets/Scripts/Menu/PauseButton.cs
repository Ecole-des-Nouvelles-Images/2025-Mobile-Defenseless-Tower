using UnityEngine;
using EventBus = Utils.EventBus;

namespace Menu
{
    public class PauseButton : MonoBehaviour
    {
        public GameObject PausePanel;

        public void OnPause()
        {
            Instantiate(PausePanel, GameObject.Find("Canvas").transform);
            EventBus.OnGamePaused?.Invoke();
            Debug.Log("OnGame Pause");
        }
    }
}
