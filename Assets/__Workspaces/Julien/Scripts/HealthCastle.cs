using TMPro;
using UnityEngine;
using Utils;

public class HealthCastle : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private void OnEnable()
    {
        EventBus.OnCastleTakedDamage += SetText;
        EventBus.OnCastleSpawn += Reset;
    }

    private void OnDisable()
    {
        EventBus.OnCastleTakedDamage -= SetText;
        EventBus.OnCastleSpawn -= Reset;
    }

    private void Reset(int health)
    {
        _text.text = health + " / ";
    } 
    private void SetText(int health)
    {
        if (health < 0)
        {
            _text.text = 0 + " / ";
            return;
        }
        _text.text = health + " / ";
    }
}
