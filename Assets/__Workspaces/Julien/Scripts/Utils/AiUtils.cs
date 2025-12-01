using System;
using System.Collections.Generic;
using UnityEngine;

public static class AiUtils
{
    
    // Convertie la matrix de Cell En matrix de int
    public static int[,] ConvertMatrixCellToInt(Cell[,] cellMatrix)
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

        return matrix;
    }

    // Devra retourné une list de HeuristicResult
    // Renvoie une list de HeuristicResult qui devra ensuite être classé dans l'ordre décroissant afin de placer les bonne
    // tour avec le bon heuristicResult
    public static List<HeuristicResult> SetHeuristicResult(int[,] matrix, List<DefenseBaseData> defenseBaseDatas)
    {
        List<HeuristicResult> heuristicResults = new List<HeuristicResult>();

        int height = matrix.GetLength(0);
        int width = matrix.GetLength(1);
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (matrix[i,j] == 0)
                {
                    heuristicResults.Add(ChoiceBetterTower(new Vector2Int(i,j), matrix, defenseBaseDatas));
                }
            }
        }

        return heuristicResults;
    }
    
    // Renvoie le meilleur heuristicResult, en se basant sur la list de data.Si chaque défense vaut 0 alors l'heuristic serra null
    public static HeuristicResult ChoiceBetterTower(Vector2Int position, int[,] matrix, List<DefenseBaseData> defenseBaseDatas)
    {
        HeuristicResult heuristicResult = new HeuristicResult();
        List<HeuristicResult> heuristicResults = new List<HeuristicResult>();
        
        foreach (DefenseBaseData data in defenseBaseDatas)
        {
            heuristicResults.Add(AdditionHeuristic(data, position, matrix));
        }
        
        return heuristicResult;
    }
    
    // addition la position à chaque CoordHeuristic.Heurisic et multiplier l'heuristic par le int[position] de la matix
    public static HeuristicResult AdditionHeuristic(DefenseBaseData dataDefense ,Vector2Int position, int[,] matrix)
    {
        foreach (CoordHeurstic heuristic in dataDefense.Heurstics)
        {
            Vector2Int heurCoord = new Vector2Int(position.x + heuristic.Coord.x, position.y + heuristic.Coord.y);
            bool outOfRange = CheckIfOutOfRange(matrix, heurCoord);
            if (outOfRange) continue;
            //heuristic.Heuristic++;
        }
    }

    
    // Vérifier si la position envoyer est out of range de la matrix
    public static bool CheckIfOutOfRange(int[,] matrix, Vector2Int positionToCheck)
    {
        int height = matrix.GetLength(0);
        int width = matrix.GetLength(1);
        
        if (positionToCheck.x > 0 && positionToCheck.x <= height && positionToCheck.y > 0 && positionToCheck.y <= width)
        {
            return false;
        }

        return true;
    }
}

public struct HeuristicResult
{
    // La data de la tour 
    public DefenseBaseData DefenseBaseData; 
    
    // La position de la tour
    public Vector2Int position;
    
    // La valeur de L'heuristique
    public int HeuristicValue;
}
