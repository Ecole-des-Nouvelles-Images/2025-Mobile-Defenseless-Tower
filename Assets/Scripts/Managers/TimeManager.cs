using TMPro;
using UnityEngine;
using Utils;

namespace Managers
{
    public class TimeManager : MonoBehaviourSingleton<TimeManager>
    {
        [SerializeField] private TMP_Text _text;
    
        [Header("Chronometre")] 
        
        public bool GameIsPlaying;
        public float MaxChrono;
        public float CurrentChrono;

        [SerializeField] private bool _timeStartedOnTime;
        private void Awake()
        {
            if (GetComponent<TMP_Text>()) _text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            EventBus.OnplayerPlaceTroup += StartChrono;
            EventBus.OnGamePaused += StopChrono;
            EventBus.OnGameResume += ResumeChrono;
            EventBus.OnLevelFinished += StopChrono;
            EventBus.OnIaPlaceTower += SetChrono;
        }

        private void OnDisable()
        {
            EventBus.OnplayerPlaceTroup -= StartChrono;
            EventBus.OnGamePaused -= StopChrono;
            EventBus.OnGameResume -= ResumeChrono;
            EventBus.OnLevelFinished -= StopChrono;
            EventBus.OnIaPlaceTower -= SetChrono;
        }

        private void Update()
        {
            if (GameIsPlaying)
            {
                CurrentChrono -= Time.deltaTime;
            
                int minutes = Mathf.FloorToInt(CurrentChrono / 60);
                int seconds = Mathf.FloorToInt(CurrentChrono % 60);

                _text.text = $"{minutes:00}:{seconds:00}";
            }

            if (CurrentChrono <= 0 && _timeStartedOnTime)
            {
                ChronoIsFinished();
            }
        }

        public void SetChrono()
        {
            int minutes = Mathf.FloorToInt(MaxChrono / 60);
            int seconds = Mathf.FloorToInt(MaxChrono % 60);

            _text.text = $"{minutes:00}:{seconds:00}";
        }
        public void StartChrono()
        {
            CurrentChrono = MaxChrono;
            GameIsPlaying = true;
            _timeStartedOnTime = true;
        }

        public void ResumeChrono()
        {
            GameIsPlaying = true;
        }
    
        public void StopChrono()
        {
            GameIsPlaying = false;
        }

        public void ChronoIsFinished()
        {
            EventBus.OnChronoAreFinished?.Invoke();
            GameIsPlaying = false;
            _text.text = " GAME OVER ! ";
            Debug.Log("Le jeu est fini");
            // Pensez à faire un panel de fin le load scene à la rache est temporaire.
        }
    }
}
