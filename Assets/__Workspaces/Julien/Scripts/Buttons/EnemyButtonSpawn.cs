using System;
using TMPro;
using UnityEngine;

public class EnemyButtonSpawn : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    public EnemyClass EnemyClass;

    private void Start()
    {
        _priceText.text = EnemyClass.price.ToString();
    }

    public void OnClick()
    {
        SpawnManager.Instance.Spawn(EnemyClass);
    }
}
