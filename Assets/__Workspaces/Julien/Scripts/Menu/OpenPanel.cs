using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        PanelToOpen.SetActive(true);
        PanelToClose.SetActive(false);
    }
}
