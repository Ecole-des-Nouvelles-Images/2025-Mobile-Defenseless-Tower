using Managers;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour, IClickable
{
    public int MinMoney;
    public int MaxMoney;

    public int Speed;
    public bool LeftSide;

    public GameObject PrefabVFX;
    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    public void SetUp(bool leftSide)
    {
        LeftSide = leftSide;
        RotateBird();
    }
    
    private void RotateBird()
    {
        if (!LeftSide)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void OnClick()
    {
        int rand = Random.Range(MinMoney, MaxMoney + 1);
        InventoryHandler.Instance.Money += rand;
        SpawnManager.Instance.SpawnVfxInPosition(PrefabVFX, transform.position);
        Destroy(gameObject);
        Debug.Log("grougrogu");
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
    }
}
