using UnityEngine;

namespace ScriptableObjectsScripts.Difficulty
{
    [CreateAssetMenu(fileName = "DifficultySpline", menuName = "Scriptable Objects/DifficultySpline")]
    public class SoDifficultySpline : ScriptableObject
    {
        public int KnotCount; // Nombre de fois où le terrain change de direction
        public int TerrainSize = 21; // Taille du terrain dans la longeur

        public Vector2Int StartPosX; // Position où le chemin commence ( en random ) 
        public Vector2Int EndPosX; // Position où le chemin fini ( en random )

        public Vector2Int RandomPos; // La longeur d'un chemin quand il change de direction ( en random )
        public Vector2Int MaxWidth; // Le clamp du chemin sur la largeur
        public Vector2Int MaxHeight; // Le clamp du chemin sur la longeur
    }
}
