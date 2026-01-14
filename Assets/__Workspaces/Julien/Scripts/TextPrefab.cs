using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextPrefab : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;

   private void Start()
   {
      Destroy(gameObject, 1f);
      
      Vector3 direction = transform.position;
      direction = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
      transform.DOMove( direction,1f);
   }

   public void SetUp(string text,Color color)
   {
      _text.text = text;
      _text.color = color;
   }
}
