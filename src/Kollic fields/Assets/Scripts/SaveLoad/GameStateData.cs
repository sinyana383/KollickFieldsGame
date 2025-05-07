using UnityEngine;
using static GameState;

[System.Serializable]
public class GameStateData
{
    public int missingPeople;
    public int mainEnemy;
    public int idol;
    public int mainCharacter;

    public GameStateData(GameState gameState) 
    {
        missingPeople = (int)gameState.missingPeople;
        mainEnemy = (int)gameState.mainEnemy;
        idol = (int)gameState.idol;
        mainCharacter = (int)gameState.mainCharacter;
    }
}
