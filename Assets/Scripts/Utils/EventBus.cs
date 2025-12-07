using System;

namespace Utils
{
    public static class EventBus
    {
        // GameLoop
    
        public static Action OnGameStart;
        public static Action OnGameEnd;
        
        public static Action OnGamePaused;
        public static Action OnGameResume;
        public static Action OnChronoAreFinished;
        
        public static Action OnSelection;
        public static Action OnNextLevel;
        public static Action OnLevelStart;
        public static Action OnLevelFinished;

        public static Action<int> OnCastleTakedDamage;
        public static Action<int> OnCastleSpawn;
        
        public static Action OnDifficultyAreSelected;
    
        // Player
    
        public static Action OnPlayerSelectCard;
        public static Action OnplayerPlaceTroup;
        public static Action OnPlayerPlaceSpell;
        public static Action OnInventoryAreUpdated;
        public static Action OnPlayerClicked;
        public static Action OnPlayerUseMoney;
        public static Action OnPlayerUseElixir;
        public static Action OnPlayerTakedCard;
    
        // IA
        public static Action OnTerrainGenerate;
        public static Action OnIaPlaceTower;
    
    
    }
}
