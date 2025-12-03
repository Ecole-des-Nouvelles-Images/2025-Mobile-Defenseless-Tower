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
        }
    
        public void OnClick()
        {
            Upgrade.Apply(_inventory);
            EventBus.OnPlayerTakedCard?.Invoke();
        
        }
    }
}
