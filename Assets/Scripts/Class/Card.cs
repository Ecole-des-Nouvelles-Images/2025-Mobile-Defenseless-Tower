using Player;
using ScriptableObjectsScripts.Upgrades;
using TMPro;
using UnityEngine;
using Utils;
using Image = UnityEngine.UI.Image;

namespace Class
{
    public class Card : MonoBehaviour
    {
        public Upgrade Upgrade;
        private string _name;
        private Sprite _sprite;
        private string _description;

        [SerializeField] private InventoryHandler _inventory;
    
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;
        [SerializeField] private Image _typeImage;
        
        [Header("Rarity")]
        [SerializeField] private Sprite _communCadre;
        [SerializeField] private Sprite _moyenCadre;
        [SerializeField] private Sprite _rareCadre;
        
        [Header("Type")]
        
        [SerializeField] private Sprite _enemyType;
        [SerializeField] private Sprite _spellType;
        [SerializeField] private Sprite _diversType;

       

        private void Start()
        {
            SetUp(Upgrade);
        }

        public void SetUp(Upgrade upgrade)
        {
            Upgrade = upgrade;
            _name = upgrade.name;
            _sprite = upgrade.Srite;
            _description = upgrade.Description;

            _image.sprite = _sprite;
            _text.text = _description;
        
            _inventory = GameObject.Find("InventoryHandler").GetComponent<InventoryHandler>();
            Image image = gameObject.GetComponent<Image>();
            
            if (Upgrade.Rarity is Rarity.Commun) image.sprite = _communCadre;
            if (Upgrade.Rarity is Rarity.Moyen) image.sprite = _moyenCadre;
            if (Upgrade.Rarity is Rarity.Rare) image.sprite = _rareCadre;
            
            if(upgrade is UpgradeEnemy) _typeImage.sprite = _enemyType;
            if(upgrade is UpgradeSpell) _typeImage.sprite = _spellType;
            if(upgrade is UpgradeDivert) _typeImage.sprite = _diversType;
        }
    
        public void OnClick()
        {
            Debug.Log("UPGRADE");
            Upgrade.Apply(_inventory);
            EventBus.OnPlayerTakedCard?.Invoke();
        }
        
        
    }
}
