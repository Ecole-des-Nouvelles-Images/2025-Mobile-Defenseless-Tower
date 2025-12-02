using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class OpenScene : MonoBehaviour
    {
        public string SceneName;
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
            SceneManager.LoadScene(SceneName);
        }
    }
}
