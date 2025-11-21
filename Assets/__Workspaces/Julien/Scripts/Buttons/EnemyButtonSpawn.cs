using UnityEngine;

public class EnemyButtonSpawn : MonoBehaviour
{
    public EnemyClass EnemyClass;

    public void OnClick()
    {
        SpawnManager.Instance.Spawn(EnemyClass);
    }
}
