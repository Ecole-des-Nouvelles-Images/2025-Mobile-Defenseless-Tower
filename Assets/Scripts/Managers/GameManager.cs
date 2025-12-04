using ScriptableObjectsScripts.Difficulty;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] private SplineManager _splineManager;
        [SerializeField] private GameObject _cardPropositionPanel;

        [Header("Card")] 
        public int NumberCard;


        public SoDifficultySpline DifficultySplineTest;
    
        private void OnEnable()
        {
            EventBus.OnLevelFinished += LoadSelectionCard;
            EventBus.OnPlayerTakedCard += LoadNewLevel;
        }
    
        private void OnDisable()
        {
            EventBus.OnLevelFinished -= LoadSelectionCard;
            EventBus.OnPlayerTakedCard -= LoadNewLevel;
        }

        private void Start()
        {
            EventBus.OnGameStart?.Invoke();
        }

        public void LoadNewLevel()
        {
            EventBus.OnNextLevel?.Invoke();
        }

        public void LoadSelectionCard()
        {
            _cardPropositionPanel.SetActive(true);
            _cardPropositionPanel.GetComponent<CardManager>().LoadCardProposition();
        }
    }
}
