using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Menu
{
    public class OnResumeButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>(); // récupère automatiquement le Button sur ce GameObject
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void OnClick()
        {
            EventBus.OnGameResume?.Invoke();
            Debug.Log("OnGame resume");
        }
    }
}