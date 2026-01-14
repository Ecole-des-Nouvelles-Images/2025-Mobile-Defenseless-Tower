using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ChangeLanguageButton : MonoBehaviour
{
    public int LocalizationID;

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LocalizationID];
    }
}
