using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private string savefileName = "taskManager";
    [SerializeField] private Comment winComment;
    [SerializeField] public bool wasWin = false;
    public List<TaskBranch> tasksPool;
    public enum TasksNames // Same order for tasksPool elements
    {
        EnterField,
        FindPeople,
        KillAkratit,
        FindIdol,
        DestroyIdol,
        RunHome,
        GoHome
    }

    public GameState gameState;
    public AudioSource audioSource;
    
    [Header("UI")]
    public Transform tasksContainer;
    public TaskBox taskBoxPrefab;
    public TextMeshProUGUI commentText;
    public float delayBetweenComments = 3f;
    
    public void SaveTaskManager() => SaveManager.SaveData(new SaveData.TaskManagerData(this), savefileName);

    public bool LoadTaskManager()
    {
        SaveData.TaskManagerData taskManagerData = SaveManager.LoadData<SaveData.TaskManagerData>(savefileName);
        
        if (taskManagerData == null)
        {
            return false;
        }
        
        for (int i = 0; i < taskManagerData.taskStates.Length; i++)
        {
            tasksPool[i].taskState = (TaskBranch.TaskState)taskManagerData.taskStates[i];
        }
        wasWin = taskManagerData.wasWin;
        return true;
    }
    
    private void Start()
    {
        if (LoadTaskManager())
            LoadTaskManager();
        else
        {
            NotStartedAllTasks();
            tasksPool[0].taskState = TaskBranch.TaskState.Started;
        }
        RefreshActiveTasksDisplay();
    }

    private void NotStartedAllTasks() 
    {
        foreach (var task in tasksPool)
            task.taskState = TaskBranch.TaskState.NotStarted;
    }


    void PlayTaskComments(TasksNames name)
    {
        PlayComments(tasksPool[(int)name]);
    }
    private void OnEnable()
    {
        EventManager.Save.OnSaveGame += SaveTaskManager;
        EventManager.Zone.OnFieldEntered += PlayTaskComments;
        EventManager.Bodies.OnBodiesFound += PlayTaskComments;
        EventManager.Akratit.OnAkratitDeath += PlayTaskComments;
        EventManager.Idol.OnIdolFound += PlayTaskComments;
        EventManager.Idol.OnIdolDestroyed += PlayTaskComments;
        EventManager.Akratit.RunFromAkratit += CheckRunHome;
    }

    private void CheckRunHome(TasksNames arg0)
    {
        if (gameState.akratit == GameState.SubjectState.Found)
        {
            PlayTaskComments(arg0);
        }
    }

    private void OnDisable()
    {
        EventManager.Save.OnSaveGame -= SaveTaskManager;
        EventManager.Zone.OnFieldEntered -= PlayTaskComments;
        EventManager.Bodies.OnBodiesFound -= PlayTaskComments;
        EventManager.Akratit.OnAkratitDeath -= PlayTaskComments;
        EventManager.Idol.OnIdolFound -= PlayTaskComments;
        EventManager.Idol.OnIdolDestroyed -= PlayTaskComments;
    }

    public void ChangeTaskList(TaskBranch task, TaskBranch.TaskState state)
    {
        foreach (TaskBranch t in tasksPool)
        {
            if (t == task)
            {
                t.taskState = state;
                break;
            }
        }
    }

    public void RefreshActiveTasksDisplay()
    {
        TaskBox[] tasksBoxes = tasksContainer.GetComponentsInChildren<TaskBox>();
        for (int i = 0; i < tasksBoxes.Length; i++) // clear tasks, may be optimised
            Destroy(tasksBoxes[i].gameObject);
        foreach (TaskBranch task in tasksPool) // display started tasks
        {
            if (task.taskState != TaskBranch.TaskState.Started)
                continue;
            TaskBox newTask = Instantiate(taskBoxPrefab, tasksContainer);
            newTask.ChangeTitle(task.title);
        }
    }
    
    public void PlayComments(TaskBranch task)
    {
        if (task.taskState != TaskBranch.TaskState.Started && task.taskState != TaskBranch.TaskState.NotStarted)
            return;
        EventManager.Save.OnSaveAllDisable?.Invoke();
        task.taskState = TaskBranch.TaskState.InProcess;
        Debug.Log($"Starting comments on task {task}");

        Comment curComment = task.startComment;
        if (curComment == null) 
        {
            Debug.Log($"No start comments found");
            task.taskState = TaskBranch.TaskState.Completed;
            EventManager.Save.OnSaveAllEnable?.Invoke();
            return;
        }


        StartCoroutine(DisplayComments(curComment));
    }
    
    IEnumerator DisplayComments(Comment curComment)
    {
        try
        {
            while (curComment)
            {
                Debug.Log(curComment.textLine);
                commentText.text = curComment.textLine;

                if (curComment.voiceLine != null && audioSource != null)
                {
                    audioSource.clip = curComment.voiceLine;
                    audioSource.Play();

                    while (audioSource.isPlaying)
                    {
                        yield return null;
                    }
                }
                else if (!string.IsNullOrEmpty(curComment.textLine))
                {
                    yield return new WaitForSeconds(delayBetweenComments);
                }

                if (curComment.tasksToChange != null && curComment.tasksToChange.Count > 0)
                {
                    for (int i = 0; i < curComment.tasksToChange.Count; i++)
                    {
                        ChangeTaskList(curComment.tasksToChange[i], curComment.taskState[i]);
                    }
                    RefreshActiveTasksDisplay();
                }
            
                if (curComment.nextComments == null || curComment.nextComments.Count == 0)
                {
                    break;
                }
                else
                {
                    int index = (int)gameState.GetSubjectState(curComment.subjectsToCheck);
                    Debug.Log($"{curComment}");
                    curComment = curComment.nextComments[index];
                }
            }
        }
        finally
        {
            // Ensure saving is re-enabled even if an error occurs
            EventManager.Save.OnSaveAllEnable?.Invoke();
        }
        commentText.text = "";
        CheckMainThingsDone();
    }

    public void CheckMainThingsDone()
    {
        if (gameState.bodies == GameState.SubjectState.Found && gameState.akratit == GameState.SubjectState.Destroyed 
                                                             && gameState.idol == GameState.SubjectState.Destroyed && !wasWin)
        {
            Debug.Log("Game win");
            wasWin = true;
            StartCoroutine(DisplayComments(winComment));
        }
    }
}
