using Buttons;
using Class;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

public class CursorController : MonoBehaviour
{

    public GameObject SlectedCard;
    public bool HaveSpeel;
    public GameObject Cursor;
    
    public Vector2 Direction;
    public float Speed;

    [SerializeField] private GameObject _selectedCard;
    [SerializeField] SpellClass SpellClass;
    [SerializeField] private EventSystem _eventSystem;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Moving();
        SlectedCard = _eventSystem.currentSelectedGameObject;
    }

    private void Moving()
    {
        if (!HaveSpeel) return;
        Vector3 moveDirection = new Vector3(- Direction.y, 0, Direction.x);
        _rigidbody.linearVelocity = moveDirection * Speed;
    }

    public void EnableCursorSpell()
    {
        HaveSpeel = true;
        Cursor.SetActive(true);
        SpellClass spellClass = SlectedCard.GetComponent<SpellButton>().SpellClass;
        SpellClass = spellClass;
        
        InventoryHandler.Instance.EquipedSpell = spellClass;
    }

    public void PlaceSpell()
    {
        SpellClass currentSpellClass = SlectedCard.GetComponent<SpellButton>().SpellClass;
        Debug.Log("Want drop" + currentSpellClass.SpellData.name);
        if (HaveSpeel && SpellClass == currentSpellClass)
        {
            ClickManager.Instance.LastPosition = transform.position;
            InventoryHandler.Instance.DropSpell();
        
            HaveSpeel = false;
            Cursor.SetActive(false);
        }
        else
        {
            Debug.Log("il n'est pas le même sort donc on change ");
        }
    }
}
