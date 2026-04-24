using System;
using Buttons;
using Class;
using Menu;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
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
    [SerializeField] private PauseButton _pauseButton;
    
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private ControllerInputHandler _inputHandler;
    private InputSystemUIInputModule _uiInputModule;
    private bool _gameInPause;
    
    /// <summary>
    /// Récupère les ref
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        _inputHandler = GetComponent<ControllerInputHandler>();
        
        EventBus.OnPlayerSelectSpell += ActiveCursor;
        EventBus.OnGameResume += ResumeGame;
    }

    /// <summary>
    /// Récupère la ref du InputSystemUiModule 
    /// </summary>
    private void Start()
    {
        _uiInputModule = _eventSystem.gameObject.GetComponent<InputSystemUIInputModule>();
    }

    /// <summary>
    /// Activer le curseur et les input du joueur
    /// Desactiver l'inpute de l'UI afin d'éviter les probleme
    /// </summary>
    private void ActiveCursor()
    {
        HaveSpeel = true;
        Cursor.SetActive(true);
        _selectedCard = _eventSystem.currentSelectedGameObject;
        _playerInput.enabled = true;
        _inputHandler.enabled = true;
        _uiInputModule.enabled = false;
    }

    /// <summary>
    /// Re activer les input de l'ui et désactiver ceux du joueur
    /// Instantier le sort depuis le manager 
    /// </summary>
    public void ClickWithSpell()
    {
        if (!HaveSpeel || _gameInPause) return;
        HaveSpeel = false;
        //_playerInput.enabled = false;
        _inputHandler.enabled = false;
        _uiInputModule.enabled = true;
        Cursor.SetActive(false);
        
        ClickManager.Instance.LastPosition = transform.position;
        InventoryHandler.Instance.DropSpell();
        SlectedCard.GetComponent<SpellButton>().UnselectedVisuel();
        Debug.Log("Player place spell");
    }

    /// <summary>
    /// Desactiver les input du joueur et re activer ceux de l'UI
    /// </summary>
    public void Cancel()
    {
        HaveSpeel = false;
       // _playerInput.enabled = false;
        _inputHandler.enabled = false;
        _uiInputModule.enabled = true;
        Cursor.SetActive(false);
        
        SlectedCard.GetComponent<SpellButton>().UnselectedVisuel();
    }

    private void Update()
    {
        Moving();
        SlectedCard = _eventSystem.currentSelectedGameObject;
    }

    private void Moving()
    {
        if (!HaveSpeel || _gameInPause) return;
        Vector3 moveDirection = new Vector3(- Direction.y, 0, Direction.x);
        _rigidbody.linearVelocity = moveDirection * Speed;
    }

    public void PauseGame()
    {
        _pauseButton.OnPause();
        _gameInPause = true;
    }

    public void ResumeGame()
    {
        _gameInPause = false;
    }
}
