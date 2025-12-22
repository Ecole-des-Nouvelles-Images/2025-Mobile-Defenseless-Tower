using System;
using Class;
using DG.Tweening;
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

        private Vector3 _basePosition;
        
        private void OnEnable()
        {
            EventBus.OnLevelFinished += DisableClick;
            EventBus.OnPlayerTakedCard += EnableClick;
            EventBus.OnPlayerPlaceSpell += UnselectedVisuel;
            EventBus.OnLevelFinished += UnselectedVisuel;
        }

        private void OnDisable()
        {
            EventBus.OnLevelFinished -= DisableClick;
            EventBus.OnPlayerTakedCard -= EnableClick;
            EventBus.OnPlayerPlaceSpell -= UnselectedVisuel;
            EventBus.OnLevelFinished -= UnselectedVisuel;
        }
        
        private void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            _image =  GetComponent<Image>();
            _image.sprite = SpellClass.SpellData.Sprite;
            _priceText.text = SpellClass.SpellData.Price.ToString();
            _basePosition = transform.position;
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
            transform.DOLocalMoveY(_basePosition.y + 30, 0.2f);
            AreSelected = true;
        }
        
        [ContextMenu("Reset visual")]
        private void UnselectedVisuel()
        {
            GameObject parent = transform.parent.gameObject;
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponent<SpellButton>().AreSelected = false;
                parent.transform.GetChild(i).gameObject.transform.DOLocalMoveY(_basePosition.y, 0.2f);
            }
            InventoryHandler.Instance.EquipedSpell = null;
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
