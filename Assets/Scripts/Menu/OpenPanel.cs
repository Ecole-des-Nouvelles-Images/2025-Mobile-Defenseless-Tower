using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class OpenPanel : MonoBehaviour
    {
        public GameObject PanelToOpen;
        public GameObject PanelToClose;
        [SerializeField] private Button _button;

        private void Awake()
        {
            if (gameObject.GetComponent<Button>()) _button = gameObject.GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Onclick);
        }

        public void Onclick()
        {
            if (PanelToOpen) PanelToOpen.SetActive(true);
            if (PanelToClose) PanelToClose.SetActive(false);
        }
    }
}
