using System;
using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.Windows;
using Utils;

public class SpawnProps : MonoBehaviour
{
    public int NumberPropos;
    
    [SerializeField] private string _ressourcePath;
    [SerializeField] private List<GameObject> _prefabsProps = new List<GameObject>();
    
   

    private void OnEnable()
    {
        EventBus.OnIaPlaceTower += Spawn;
    }

    private void OnDisable()
    {
        EventBus.OnIaPlaceTower -= Spawn;
    }

    private void Start()
    {
        _prefabsProps = Enumerable.ToList(Resources.LoadAll<GameObject>(_ressourcePath));
    }

    public void Spawn()
    {
        Cell[,] cells = PathManager.Instance.CellsMatrix;

        for (int i = 0; i < NumberPropos; i++)
        {
            Debug.Log("Props spawned");
        }
    }
}
