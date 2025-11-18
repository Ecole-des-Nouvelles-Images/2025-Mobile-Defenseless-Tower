using System;

public static class EventBus
{
    public static Action OnGameStart;
    public static Action OnGameEnd;
    public static Action OnGamePaused;
    
    // Player
    
    public static Action OnPlayerSelectCard;
    public static Action OnplayerPlaceTroup;
    public static Action OnPlayerPlaceSpell;
    
    // IA
    public static Action OnTerrainGenerate;
    public static Action OnIaPlaceTower;
    
    
}
