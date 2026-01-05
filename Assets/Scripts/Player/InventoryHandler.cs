using System.Collections.Generic;
using Buttons;
using Class;
using Managers;
using ScriptableObjectsScripts.Spells;
using ScriptableObjectsScripts.Upgrades;
using Structs;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Player
{
    public class InventoryHandler : MonoBehaviourSingleton<InventoryHandler>
    {
        [Header("-------------Money")]
        [Header("-----StartMoney")]
        public int StartMoney;
        public int StartElixir;
        
        [Header("-----MoneyParameters")]
        [SerializeField] private float _money;
        public float MaxTimeBeforeGetMoney;
        private float _timeBeforeGetMoney;
        public float MoneyParHit;
        
        [SerializeField] private float _elixir;
        public float MaxTimeBeforeGetElixir;
        private float _timeBeforeGetElixir;
        public float ElixirParHit;

        [Header("Inventory")] 
        [SerializeField] private Vector3 _elixirSpawnTextPosition;
        [SerializeField] private Vector3 _moneySpawnTextPosition;
        public float Money
        {
            get => _money;
            set
            {
                _money = value;
                EventBus.OnPlayerUseMoney?.Invoke();
            }
        }
        
        public float Elixir
        {
            get => _elixir;
            set
            {
                _elixir = value;
                EventBus.OnPlayerUseElixir?.Invoke();
            }
        }

        public SpellClass EquipedSpell;
    
        public List<EnemyClass> EnemyClass = new List<EnemyClass>();
        public List<SpellClass> SpellClasses = new List<SpellClass>();

        private List<EnemyButtonSpawn> _enemyButtonSpawns = new List<EnemyButtonSpawn>();
        private List<SpellButton> _spellButtonSpawn = new List<SpellButton>();
        
        [SerializeField] private GameObject PanelInventoryEnemy;
        [SerializeField] private GameObject PanelInventorySpell;
        [SerializeField] private GameObject prefabEnemyButton;
        [SerializeField] private GameObject prefabSpellButton;

        public Upgrade UpgradeTest;

        private bool _inPause;
        private void OnEnable()
        {
            EventBus.OnNextLevel += UpdateInventoryData;
            EventBus.OnPlayerClicked += DropSpell;
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
        }

        private void OnDestroy()
        {
            EventBus.OnNextLevel -= UpdateInventoryData;
            EventBus.OnPlayerClicked -= DropSpell;
        }
        private void OnDisable()
        {
            EventBus.OnGamePaused -= OnPause;
            EventBus.OnGameResume -= OnResume;
        }

        private void Start()
        {
            _timeBeforeGetElixir = MaxTimeBeforeGetElixir;
            _timeBeforeGetMoney = MaxTimeBeforeGetMoney;
            UpdateInventoryData();
            foreach (EnemyClass c in EnemyClass)
            {
                c.SetUpData();
            }
        
            foreach (EnemyClass c in EnemyClass)
            {
                SetVisualEnemy(c);
            }
        
            foreach (SpellClass c in SpellClasses)
            {
                c.SetData();
            }
        
            foreach (SpellClass c in SpellClasses)
            {
                SetVisuelSpell(c);
            }
        }

        private void Update()
        {
            if (_inPause) return;
            _timeBeforeGetElixir -= Time.deltaTime;
            _timeBeforeGetMoney -= Time.deltaTime;

            if (_timeBeforeGetElixir <= 0)
            {
                _timeBeforeGetElixir = MaxTimeBeforeGetElixir;
                Elixir += ElixirParHit;
                SpawnManager.Instance.SpawnTextInWorldPosition("+" + ElixirParHit, Color.magenta, _elixirSpawnTextPosition);
            }
            
            if (_timeBeforeGetMoney <= 0)
            {
                _timeBeforeGetMoney = MaxTimeBeforeGetMoney;
                Money += MoneyParHit;
                SpawnManager.Instance.SpawnTextInWorldPosition("+" + MoneyParHit, Color.yellow, _moneySpawnTextPosition);
            }
        }

        // Enemy
        public void AddEnemy(EnemyClass classToAdd)
        {
            EnemyClass.Add(classToAdd);
            SetVisualEnemy(classToAdd);
        }
        public void SetVisualEnemy(EnemyClass enemyClass)
        {
            GameObject instanciate = Instantiate(prefabEnemyButton, transform.position, quaternion.identity, PanelInventoryEnemy.transform);
            instanciate.GetComponent<EnemyButtonSpawn>().EnemyClass = enemyClass;
            _enemyButtonSpawns.Add(instanciate.GetComponent<EnemyButtonSpawn>());
        }
    
        // Sort
        public void EquipeSpell(SpellClass spellClass)
        {
            EquipedSpell = spellClass;
        }
        public void DropSpell()
        {
            if (EquipedSpell.SpellData == null)
            {
                Debug.Log("Pas de spell");
                return;
            }
            float testPrice = Elixir - EquipedSpell.Price;
            if (testPrice < 0) return;
                
            Elixir -= EquipedSpell.Price;
            GameObject spell = Instantiate(EquipedSpell.SpellData.Prefab, ClickManager.Instance.LastPosition, Quaternion.identity);
            spell.GetComponent<Spell>().SpellClass = EquipedSpell;
            EventBus.OnPlayerPlaceSpell?.Invoke();
        }
        public void UnEquipSpell()
        {
            EquipedSpell = null;
            Debug.Log("Unequipped spell");
        }
        public void SetVisuelSpell(SpellClass spellClass)
        {
            if (spellClass == null) return;
            GameObject instanciate = Instantiate(prefabSpellButton, transform.position, quaternion.identity, PanelInventorySpell.transform);
            instanciate.GetComponent<SpellButton>().SpellClass = spellClass;
            _spellButtonSpawn.Add(instanciate.GetComponent<SpellButton>());
        }


        public void UpdateAllPrice()
        {
            
        }
    
        [ContextMenu("Update")]
        public void UpdateInventoryData()
        {
            Money = StartMoney;
            Elixir = StartElixir;
            SetAllVisual();
            EventBus.OnInventoryAreUpdated?.Invoke();
        }

        public void SetAllVisual()
        {
            foreach (EnemyButtonSpawn buttonSpawn in _enemyButtonSpawns)
            {
                buttonSpawn.SetUp();
            }

            foreach (SpellButton spellButton in _spellButtonSpawn)
            {
                spellButton.SetUp();
            }
        }
        
        
        [ContextMenu("Upgrade")]
        public void Upgrade()
        {
            UpgradeTest.Apply(this);
        }
    
        private void OnPause()
        {
            _inPause = true;
        }

        private void OnResume()
        {
            _inPause = false;
        }
    }
}