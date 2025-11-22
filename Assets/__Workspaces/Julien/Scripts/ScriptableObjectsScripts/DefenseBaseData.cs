using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "Scriptable Objects/Defense")]
public class DefenseBaseData : ScriptableObject
{
    public float CoolDown;
    public float Damage;
    public float Range;

    [Header("Prefab")] 
    public GameObject Visuel;
    public GameObject ProjectilPrefab;
}
