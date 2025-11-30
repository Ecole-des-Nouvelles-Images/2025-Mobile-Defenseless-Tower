using System.Collections.Generic;
using ScriptableObjectsScripts.Difficulty;
using UnityEngine;
using Utils;

namespace Managers
{
    public class DifficultyManager : MonoBehaviourSingleton<DifficultyManager>
    {
        public int CurrentLevel;
        public int DifficulteDivise;
        public int MaxDifficulty;

        public SoDifficultySpline CurrentDifficulty;
        public List<SoDifficultySpline> DifficultySplines = new List<SoDifficultySpline>();

        private void OnEnable()
        {
            EventBus.OnGameStart += NextLevelSelection;
            EventBus.OnNextLevel += NextLevelSelection;
        }

        private void OnDisable()
        {
            EventBus.OnGameStart -= NextLevelSelection;
            EventBus.OnNextLevel -= NextLevelSelection;
        }
    
        [ContextMenu("calcule")]
        private void NextLevelSelection()
        {
            CurrentLevel++;
        
            int currentDifficulty = CurrentLevel / DifficulteDivise;
            Mathf.Ceil(currentDifficulty);
            currentDifficulty = Mathf.Clamp(currentDifficulty,1, MaxDifficulty);
        
            CurrentDifficulty = DifficultySplines[currentDifficulty - 1];
        
            EventBus.OnDifficultyAreSelected?.Invoke();
        }
    }
}
