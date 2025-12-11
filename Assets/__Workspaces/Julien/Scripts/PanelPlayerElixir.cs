using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

public class PanelPlayerElixir : MonoBehaviour
{
    [SerializeField] private TMP_Text _texteLEXIR;
    
    private void OnEnable()
    {
        _texteLEXIR.text = InventoryHandler.Instance.Elixir.ToString();
        EventBus.OnPlayerUseElixir += UpdateElixir;
        EventBus.OnInventoryAreUpdated += UpdateElixir;
    }
    private void OnDisable()
    {
        EventBus.OnPlayerUseElixir -= UpdateElixir;
        EventBus.OnInventoryAreUpdated -= UpdateElixir;
    }

    public void UpdateElixir()
    {
        _texteLEXIR.text = InventoryHandler.Instance.Elixir.ToString();
    }
}
