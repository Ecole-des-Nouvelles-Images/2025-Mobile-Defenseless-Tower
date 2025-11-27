using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public abstract class Upgrade : ScriptableObject
{
    [Header("Visuel")] 
    public string Name;
    public Sprite Srite;
    public string Description;
    
    
    public abstract void Apply(InventoryHandler inventary);
}
