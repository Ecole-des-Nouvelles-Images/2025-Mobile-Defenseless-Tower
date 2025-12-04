using System;
using UnityEngine;

public struct HeuristicResult : IEquatable<HeuristicResult>
{
    // La data de la tour 
    public DefenseBaseData DefenseBaseData; 
    
    // La position de la tour
    public Vector2Int position;
    
    // La valeur de L'heuristique
    public int HeuristicValue;

    public bool Equals(HeuristicResult other)
    {
        return Equals(DefenseBaseData, other.DefenseBaseData) && position.Equals(other.position) && HeuristicValue == other.HeuristicValue;
    }

    public override bool Equals(object obj)
    {
        return obj is HeuristicResult other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DefenseBaseData, position, HeuristicValue);
    }
}