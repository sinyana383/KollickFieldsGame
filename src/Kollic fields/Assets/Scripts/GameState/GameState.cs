using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum taskState 
    {
        None,
        Found,
        Injuried,
        Destroyed
    }

    public taskState missingPeople;
    public taskState mainEnemy;
    public taskState idol;
    public taskState mainCharacter;

    private void OnEnable()
    {
        EventManager.Idol.OnIdolFound += () => idol = taskState.Found;
    }

    private void OnDisable()
    {
        EventManager.Idol.OnIdolFound -= () => idol = taskState.Found;
    }
    
    public void SaveGameState() => SaveManager.SaveGameState(this);
    public void LoadGameState() 
    {
        GameStateData gameStateData = SaveManager.LoadGameState();

        missingPeople = (taskState)gameStateData.missingPeople;
        mainEnemy = (taskState)gameStateData.mainEnemy;
        idol = (taskState)gameStateData.idol;
        mainCharacter = (taskState)gameStateData.mainCharacter;
    }
}
