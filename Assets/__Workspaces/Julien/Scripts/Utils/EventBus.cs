using System;

public static class EventBus
{
    // GameLoop
    
    public static Action OnGameStart;
    public static Action OnGameEnd;
    public static Action OnGamePaused;
    public static Action OnSelection;
    public static Action OnNextLevel;
    public static Action OnLevelFinished;
    
    // Player
    
    public static Action OnPlayerSelectCard;
    public static Action OnplayerPlaceTroup;
    public static Action OnPlayerPlaceSpell;
    
    // IA
    public static Action OnTerrainGenerate;
    public static Action OnIaPlaceTower;
    
    
}
