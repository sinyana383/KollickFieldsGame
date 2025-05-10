using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class GameState : MonoBehaviour
{
    public enum taskState 
    {
        None,
        Found,
        Injuried,
        Destroyed
    }

    public taskState bodies;
    public taskState akratit;
    public taskState idol;
    public taskState mainCharacter;

    private void OnEnable()
    {
        EventManager.Idol.OnIdolFound += () => ChangeState(out idol, taskState.Found);
        EventManager.Akratit.OnAkratitFound += () => ChangeState(out akratit, taskState.Found);
        EventManager.Bodies.OnBodiesFound += () => ChangeState(out bodies, taskState.Found);
    }

    private void OnDisable()
    {
        EventManager.Idol.OnIdolFound -= () => ChangeState(out idol, taskState.Found);
        EventManager.Akratit.OnAkratitFound -= () => ChangeState(out akratit, taskState.Found);
        EventManager.Bodies.OnBodiesFound -= () => ChangeState(out bodies, taskState.Found);

    }

    private void ChangeState(out taskState state, taskState newState) => state = newState;
    
    public void SaveGameState() => SaveManager.SaveGameState(this);
    public void LoadGameState() 
    {
        GameStateData gameStateData = SaveManager.LoadGameState();

        bodies = (taskState)gameStateData.missingPeople;
        akratit = (taskState)gameStateData.mainEnemy;
        idol = (taskState)gameStateData.idol;
        mainCharacter = (taskState)gameStateData.mainCharacter;
    }
}
