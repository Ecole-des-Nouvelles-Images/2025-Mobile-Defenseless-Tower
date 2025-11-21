using System;
using System.Collections.Generic;
using UnityEngine;

// Assurez-vous d'avoir une classe Cell définie ailleurs si ce n'est pas déjà fait
// public class Cell {} 

public class PathManager : MonoBehaviourSingleton<PathManager>
{
    public int Height;
    public int Width; 
    
    [SerializeField] private GameObject _wayGround;
    [SerializeField] private GameObject _ground;

    [SerializeField] private Cell[,] _cellsMatrix;
    [SerializeField] private List<GameObject> _cellGameObjects = new List<GameObject>();

    private void Start()
    {
        Cell cell = new Cell();
    }

    public void SetDataPath(List<Vector3Int> vector3Ints)
    {
        Debug.Log("SetDataPath");
        _cellsMatrix =  new Cell[Width, Height];
        int height = _cellsMatrix.GetLength(0); 
        int width = _cellsMatrix.GetLength(1);

        foreach (Vector3Int vector3Int in vector3Ints)
        {
            int x = Mathf.Clamp(vector3Int.x, 0, Width - 1);
            int z = Mathf.Clamp(vector3Int.z, 0, Height - 1);
            _cellsMatrix[x, z] = new Cell();
        }
        
        SetVisual();
    }

    public void SetVisual()
    {
        ResetVisual();
        Debug.Log("SetVisual");
        int height = _cellsMatrix.GetLength(0); 
        int width = _cellsMatrix.GetLength(1); 

        for (int x = 0; x < height; x++)
        {
            for (int j = 0; j < width; j++)
            {
                if (_cellsMatrix[x, j] == null)
                {
                    GameObject instance = Instantiate(_ground, new Vector3(x, 0, j), Quaternion.identity,transform);
                    _cellGameObjects.Add(instance);
                }
                else
                {
                    GameObject instance = Instantiate(_wayGround, new Vector3(x, 0, j), Quaternion.identity, transform);
                    _cellGameObjects.Add(instance);
                }
            }
        }
    }

    public void ResetVisual()
    {
        foreach (GameObject gm in _cellGameObjects)
        {
            if (!Application.isPlaying) DestroyImmediate(gm);
            else
            {
                Destroy(gm);
            }
        }
        _cellGameObjects.Clear();
    }
}