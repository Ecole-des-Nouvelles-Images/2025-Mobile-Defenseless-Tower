using System;
using System.Collections.Generic;
using UnityEngine;

public static class AiUtils
{
    public static void ConvertMatrixCellToInt(Cell[,] cellMatrix)
    {
        int height = cellMatrix.GetLength(0);
        int width = cellMatrix.GetLength(1);
        
        int[,] matrix = new int[height, width]; 
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (cellMatrix[i, j].IsAPath)
                {
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }
    
    public static void TestAllTower(List<DefenseBaseData> baseDatas)
    {
        
    }

    // retrounera Tuple<DefenseBaseData, int>
    public static void AdditionHeuristic(DefenseBaseData dataDefense ,Vector2Int position, int[,] intMatrix)
    {
        
    }

    
}
