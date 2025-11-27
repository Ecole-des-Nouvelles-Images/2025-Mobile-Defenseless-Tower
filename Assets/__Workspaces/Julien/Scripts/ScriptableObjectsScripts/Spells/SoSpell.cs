using UnityEngine;

[CreateAssetMenu(fileName = "Speel", menuName = "Scriptable Objects/Speel")]
public class SoSpell : ScriptableObject
{
    public Sprite Sprite;
    public int Price;
    public float Time;
    public float AreaSize;
    
    public GameObject Prefab;
}
