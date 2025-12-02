using Class;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class SpellButton : MonoBehaviour
    {
        public SpellClass SpellClass;
    
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _image;
    
        private void Start()
        {
            _image =  GetComponent<Image>();
            _image.sprite = SpellClass.SpellData.Sprite;
            _priceText.text = SpellClass.SpellData.Price.ToString();
        }

        public void OnClick()
        {
        
            if (SpellClass == InventoryHandler.Instance.EquipedSpell)
            {
                InventoryHandler.Instance.UnEquipSpell();
                return;
            }
            InventoryHandler.Instance.EquipedSpell = SpellClass;
        }
    }
}
