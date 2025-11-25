using UnityEngine;

[CreateAssetMenu(fileName = "Speel", menuName = "Scriptable Objects/Speel")]
public class Spell : ScriptableObject
{
    public Sprite Sprite;
    public int Price;
    
    public GameObject Prefab;
}
