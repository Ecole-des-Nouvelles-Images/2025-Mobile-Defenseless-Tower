using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public int price;
    
    public float Speed;
    public float Health;

    public int NumberToSpawn;

    [Header("Offset position")] 
    public Vector2 OffsetX;
    public Vector2 OffsetZ;
    public float OffsetUp;

    [Header("Visual")] 
    
    public GameObject VisualPrefab;
}
