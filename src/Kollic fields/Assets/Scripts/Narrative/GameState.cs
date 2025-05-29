using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.XR;
public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    [SerializeField] string savefileName = "gameState";
    public bool gameOver;

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
        Destroyed
    }

    private void Awake()
    {
        Debug.Log("GameState Awake: " + GetInstanceID());
        // Singleton logic: preserve one instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // destroy duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // persist across scenes
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

    public void SetGameOver()
    {
        Debug.Log("Game Over");
        gameOver = true;
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        EventManager.Idol.OnIdolFound += ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitFound += AkratitFound;
        EventManager.Bodies.OnBodiesFound += ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitDeath += ChangeStateByTaskName;
        EventManager.Idol.OnIdolDestroyed += ChangeStateByTaskName;
        EventManager.Game.OnGameOver += SetGameOver;

        EventManager.Save.OnSaveGame += SaveGameState;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        EventManager.Idol.OnIdolFound -= ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitFound -= AkratitFound;
        EventManager.Bodies.OnBodiesFound -= ChangeStateByTaskName;
        EventManager.Akratit.OnAkratitDeath -= ChangeStateByTaskName;
        EventManager.Idol.OnIdolDestroyed -= ChangeStateByTaskName;
        EventManager.Game.OnGameOver -= SetGameOver;
        
        EventManager.Save.OnSaveGame -= SaveGameState;
    }

    private void ChangeState(out SubjectState state, SubjectState newState)
    {
        state = newState;
        //Debug.Log($"Idol {idol}");
        //Debug.Log($"Akratit {akratit}");
        //Debug.Log($"Bodies {bodies}");
    }

    public void SaveGameState() => SaveManager.SaveData(new SaveData.GameStateData(this), savefileName);
    public bool LoadGameState() 
    {
        SaveData.GameStateData gameStateData = SaveManager.LoadData<SaveData.GameStateData>(savefileName);

        if (gameStateData == null)
        {
            return false;
        }
        
        bodies = (SubjectState)gameStateData.missingPeople;
        akratit = (SubjectState)gameStateData.mainEnemy;
        idol = (SubjectState)gameStateData.idol;
        mainCharacter = (SubjectState)gameStateData.mainCharacter;
        return true;
    }

    private void Start()
    {
        if (Instance != this) return;
        Debug.Log("GameState start");
        LoadGameState();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("GameState OnSceneLoaded");
        if (!LoadGameState() && scene.buildIndex == 1) 
        {
            akratit = SubjectState.None;
            idol = SubjectState.None;
            bodies = SubjectState.None;
            mainCharacter = SubjectState.None;
        }
            
    }
}
