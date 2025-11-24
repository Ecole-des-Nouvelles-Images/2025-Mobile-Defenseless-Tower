using UnityEngine;

[CreateAssetMenu(fileName = "Speel", menuName = "Scriptable Objects/Speel")]
public class Spell : ScriptableObject
{
    public Sprite Sprite;
    
    public GameObject Prefab;
}
