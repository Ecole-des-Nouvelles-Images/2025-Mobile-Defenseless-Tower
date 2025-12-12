using System.Linq;
using Class;
using Player;
using Structs;
using UnityEngine;
using Utils;

namespace Managers
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        [SerializeField] private InventoryHandler _inventory;
        [SerializeField] private GameObject _birdPrefab;
        
        [Header("Prefab")]
        public GameObject VfxSpawner;
        
        [ContextMenu("Spawn")]
        public void Spawn(EnemyClass enemyclass)
        {
            float testMoney = InventoryHandler.Instance.Money - enemyclass.baseData.price;
            if (testMoney < 0) return;
        
            var newClass = _inventory.EnemyClass.FirstOrDefault(struc => struc.baseData == enemyclass.baseData);
        
            for (int i = 0; i < newClass.NumberSpawn; i++)
            {
                GameObject instantite = Instantiate(newClass.baseData.Prefab);
                instantite.GetComponent<Enemy>().EnemyClass = newClass;
            }

            InventoryHandler.Instance.Money -= newClass.price;
            EventBus.OnplayerPlaceTroup?.Invoke();
        }
        
        [ContextMenu("SpawnBird")]
        public void SpawnBird()
        {
            bool leftSide = Random.value < 0.5f;
            float randXPos = Random.Range(6f,16f);
            float posZ;
            _ = leftSide ? posZ = -2f : posZ = 24f;
            
            GameObject bird = Instantiate(_birdPrefab, new Vector3(randXPos, 3.60f, posZ), Quaternion.identity);
            bird.GetComponent<Bird>().SetUp(leftSide);
        }

        public void SpawnVfxInPosition(GameObject particleSystem, Vector3 position)
        {
            GameObject vfx = Instantiate(VfxSpawner,  position, Quaternion.identity);
            vfx.GetComponent<VfxSpawner>().SetUp(particleSystem);
        }
    }
}
