using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
public class GameState : MonoBehaviour
{
    public SubjectState bodies;
    public SubjectState akratit;
    public SubjectState idol;
    public SubjectState mainCharacter;

    public enum SubjectType
    {
        None,
        Bodies,
        Akratit,
        Idol,
        MainCharacter,
    }
    public enum SubjectState 
    {
        None,
        Found,
        Injuried,
        Destroyed
    }
    private void OnEnable()
    {
        EventManager.Idol.OnIdolFound += () => ChangeState(out idol, SubjectState.Found);
        EventManager.Akratit.OnAkratitFound += () => ChangeState(out akratit, SubjectState.Found);
        EventManager.Bodies.OnBodiesFound += () => ChangeState(out bodies, SubjectState.Found);
    }

    private void OnDisable()
    {
        EventManager.Idol.OnIdolFound -= () => ChangeState(out idol, SubjectState.Found);
        EventManager.Akratit.OnAkratitFound -= () => ChangeState(out akratit, SubjectState.Found);
        EventManager.Bodies.OnBodiesFound -= () => ChangeState(out bodies, SubjectState.Found);

    }

    private void ChangeState(out SubjectState state, SubjectState newState) => state = newState;
    
    public void SaveGameState() => SaveManager.SaveGameState(this);
    public void LoadGameState() 
    {
        GameStateData gameStateData = SaveManager.LoadGameState();

        bodies = (SubjectState)gameStateData.missingPeople;
        akratit = (SubjectState)gameStateData.mainEnemy;
        idol = (SubjectState)gameStateData.idol;
        mainCharacter = (SubjectState)gameStateData.mainCharacter;
    }
}
