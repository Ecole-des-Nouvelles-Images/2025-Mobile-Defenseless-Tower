using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public abstract class Upgrade : ScriptableObject
{
    public abstract void Apply(InventoryHandler inventary);
}
