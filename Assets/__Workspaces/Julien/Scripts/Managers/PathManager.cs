using System;
using UnityEngine;

// Assurez-vous d'avoir une classe Cell définie ailleurs si ce n'est pas déjà fait
// public class Cell {} 

public class PathManager : MonoBehaviour
{
    public int Height;
    public int Width; 
    
    [SerializeField] private GameObject _wayGround;
    [SerializeField] private GameObject _ground;

    [SerializeField] private Cell[,] _cellsMatrix;

    private void Start()
    {
        Cell cell = new Cell();

        _cellsMatrix = new Cell[15,22]
        {
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,cell,cell,cell,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,cell,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,cell,cell,cell,null,null,null,null,null,cell,null,null,cell,null,null, null, null},
            {null,null,null,null,null,cell,cell,null,cell,null,null,null,null,null,cell,null,null,cell,null,null, null, null},
            {cell,cell,cell,cell,cell,cell,null,null,cell,null,null,null,null,null,cell,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,cell,null,null,null,null,null,cell,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,cell,cell,cell,cell,cell,cell,cell,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,cell,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,cell,cell,cell, cell, cell},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null, null},
            {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null, null, null},
        };
        
        int height = _cellsMatrix.GetLength(0); 
        int width = _cellsMatrix.GetLength(1); 

        for (int x = 0; x < height; x++)
        {
            for (int j = 0; j < width; j++)
            {
                if (_cellsMatrix[x, j] == null)
                {
                    Instantiate(_ground, new Vector3(x, 0, j), Quaternion.identity);
                }
                else
                {
                    Instantiate(_wayGround, new Vector3(x, 0, j), Quaternion.identity);
                }
            }
        }
    }
}