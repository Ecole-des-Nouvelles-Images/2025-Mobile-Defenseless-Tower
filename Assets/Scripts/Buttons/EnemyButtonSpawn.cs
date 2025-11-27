using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class EnemyButtonSpawn : MonoBehaviour
    {
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _image;
        public EnemyClass EnemyClass;

        private void Start()
        {
            _image = GetComponent<Image>();
            SetUp();
        }

        public void SetUp()
        {
            _priceText.text = EnemyClass.price.ToString();
            _image.sprite = EnemyClass.baseData.Sprite;
        }

        public void OnClick()
        {
            SpawnManager.Instance.Spawn(EnemyClass);
        }
    }
}
