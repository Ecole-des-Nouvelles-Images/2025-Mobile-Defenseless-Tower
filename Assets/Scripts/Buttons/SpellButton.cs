using Class;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Buttons
{
    public class SpellButton : MonoBehaviour
    {
        public bool AreSelected;
        public SpellClass SpellClass;
    
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _image;
    
        private void OnEnable()
        {
            EventBus.OnLevelFinished += DisableClick;
            EventBus.OnPlayerTakedCard += EnableClick;
        }

        private void OnDisable()
        {
            EventBus.OnLevelFinished -= DisableClick;
            EventBus.OnPlayerTakedCard -= EnableClick;
        }
        
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
                UnselectedVisuel();
                return;
            }
            UnselectedVisuel();
            SelectedVisual();
            InventoryHandler.Instance.EquipedSpell = SpellClass;
        }

        public void SelectedVisual()
        {
            GetComponent<Image>().color = Color.yellow;
            AreSelected = true;
        }
        
        private void UnselectedVisuel()
        {
            GameObject parent = transform.parent.gameObject;
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponent<SpellButton>().AreSelected = false;
                parent.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        
        private void EnableClick()
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        private void DisableClick()
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
