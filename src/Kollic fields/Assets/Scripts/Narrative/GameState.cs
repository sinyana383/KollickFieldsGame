using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
public class GameState : MonoBehaviour
{
    [SerializeField] string savefileName = "gameState";
    public bool gameOver;
    
    public SubjectState bodies;
    public SubjectState akratit;
    public SubjectState idol;
    public SubjectState mainCharacter; //???

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
        Destroyed
    }

    public SubjectState GetSubjectState(SubjectType subjectType)
    {
        switch (subjectType)
        {
            case SubjectType.Bodies: return bodies;
            case SubjectType.Akratit: return akratit;
            case SubjectType.Idol: return idol;
            case SubjectType.MainCharacter: return mainCharacter;
        }
        return SubjectState.None;
    }

    private void ChangeStateByTaskName(TaskManager.TasksNames name)
    {
        switch (name)
        {
            case TaskManager.TasksNames.DestroyIdol: ChangeState(out idol, SubjectState.Destroyed);return;
            case TaskManager.TasksNames.FindIdol: ChangeState(out idol, SubjectState.Found);return;
            case TaskManager.TasksNames.KillAkratit: ChangeState(out akratit, SubjectState.Destroyed);return;
            case TaskManager.TasksNames.FindPeople: ChangeState(out bodies, SubjectState.Found); return;
        }
    }

    public void AkratitFound() => ChangeState(out akratit, SubjectState.Found);
    public void SetGameOver() => gameOver = true;
    
    private void OnEnable()
    {
        EventManager.Idol.OnIdolFound += ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitFound += AkratitFound;
        EventManager.Bodies.OnBodiesFound += ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitDeath += ChangeStateByTaskName;
        EventManager.Idol.OnIdolDestroyed += ChangeStateByTaskName;
        EventManager.GameOver.OnGameOver += SetGameOver;

        EventManager.Save.OnSaveGame += SaveGameState;
    }
    private void OnDisable()
    {
        EventManager.Idol.OnIdolFound -= ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitFound -= AkratitFound;
        EventManager.Bodies.OnBodiesFound -= ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitDeath -= ChangeStateByTaskName;
        EventManager.Idol.OnIdolDestroyed -= ChangeStateByTaskName;
        EventManager.GameOver.OnGameOver -= SetGameOver;
        
        EventManager.Save.OnSaveGame -= SaveGameState;
    }

    private void ChangeState(out SubjectState state, SubjectState newState)
    {
        state = newState;
    }

    public void SaveGameState() => SaveManager.SaveData(new SaveData.GameStateData(this), savefileName);
    public void LoadGameState() 
    {
        SaveData.GameStateData gameStateData = SaveManager.LoadData<SaveData.GameStateData>(savefileName);

        if (gameStateData == null)
        {
            return;
        }
        
        bodies = (SubjectState)gameStateData.missingPeople;
        akratit = (SubjectState)gameStateData.mainEnemy;
        idol = (SubjectState)gameStateData.idol;
        mainCharacter = (SubjectState)gameStateData.mainCharacter;
    }

    private void Start()
    {
        LoadGameState();
    }
}
