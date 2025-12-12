using System;
using System.Collections.Generic;
using Managers;
using Structs;
using UnityEngine;

namespace Utils
{
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
        
            //heuristicResults.Add(ChoiceBetterTower(new Vector2Int(7,3), matrix, defenseBaseDatas));
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i,j] == 0 && !PathManager.Instance.CellsMatrix[i,j].IsBlocked)
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
            List<HeuristicResult> heuristicResults = new List<HeuristicResult>();
            HeuristicResult bestResult = new HeuristicResult();
        
            foreach (DefenseBaseData data in defenseBaseDatas)
            {
                heuristicResults.Add(AdditionHeuristic(data, position, matrix));
            }

            foreach (HeuristicResult heur in heuristicResults)
            {
                if (heur.HeuristicValue > bestResult.HeuristicValue)
                {
                    bestResult = heur;
                }
            }

            if (bestResult.HeuristicValue == 0)
            {
                bestResult.HeuristicValue = Int32.MinValue;
                bestResult.DefenseBaseData = null;
                bestResult.position =  position;
            
                //Debug.LogWarning(" la position " + bestResult.position + " est null et la value " + bestResult.HeuristicValue);
            }

            if (bestResult.HeuristicValue > 0)
            {
                //Debug.Log(" le best " + bestResult.HeuristicValue + " a la pose " + bestResult.position + " et la data " + bestResult.DefenseBaseData.name);
            }
        
            return bestResult;
        }
    
        // addition la position à chaque CoordHeuristic.Heurisic et multiplier l'heuristic par le int[position] de la matix
        public static HeuristicResult AdditionHeuristic(DefenseBaseData dataDefense ,Vector2Int position, int[,] matrix)
        {
            HeuristicResult heuristicResult = new HeuristicResult();
            heuristicResult.DefenseBaseData = dataDefense;
            heuristicResult.position = position;
        
            foreach (CoordHeurstic coord in dataDefense.Heurstics)
            {
                Vector2Int pos = new Vector2Int(position.x + coord.Coord.x, position.y + coord.Coord.y);
                bool outOfRange = CheckIfOutOfRange(matrix, pos);
                if (outOfRange) continue;

                heuristicResult.HeuristicValue += matrix[pos.x, pos.y] * coord.Heuristic;
            }
            return heuristicResult;
        }

    
        // Vérifier si la position envoyer est out of range de la matrix
        public static bool CheckIfOutOfRange(int[,] matrix, Vector2Int pos)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            return pos.x < 0 || pos.x >= height || pos.y < 0 || pos.y >= width;
        }
    }
}