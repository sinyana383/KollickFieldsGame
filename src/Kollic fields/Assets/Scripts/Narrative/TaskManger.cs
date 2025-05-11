using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManger : MonoBehaviour
{
    public GameState gameState;
    public List<TaskBranch> tasksPool;
    public AudioSource audioSource;
    
    [Header("UI")]
    public Transform tasksContainer;
    public TaskBox taskBoxPrefab;
    public TextMeshProUGUI commentText;
    public float delayBetweenComments = 3f;
    
    private void Start()
    {
        tasksPool[0].taskState = TaskBranch.TaskState.Started;
        RefreshActiveTasksDisplay();
    }

    private void OnEnable()
    {
        EventManager.Bodies.OnBodiesFound += () => PlayComments(tasksPool[0]);
    }

    private void OnDisable()
    {
        EventManager.Bodies.OnBodiesFound -= () => PlayComments(tasksPool[0]);

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
        Debug.Log($"Starting comments on task {task}");
        Comment curComment = task.startComment;
        StartCoroutine(DisplayComments(curComment));
    }
    
    IEnumerator DisplayComments(Comment curComment)
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
                if (curComment.tasksToChange != null && curComment.tasksToChange.Count > 0)
                {
                    for (int i = 0; i < curComment.tasksToChange.Count; i++) // may be optimised
                    {
                        ChangeTaskList(curComment.tasksToChange[i], curComment.taskState[i]);
                    }
                }
                RefreshActiveTasksDisplay();
            }
            else
            {
                yield return new WaitForSeconds(delayBetweenComments);
            }
            
            if (curComment.nextComments == null || curComment.nextComments.Count == 0)
            {
                break;
            }
            else
            {
                int index = (int)gameState.GetSubjectState(curComment.subjectsToCheck);
                curComment = curComment.nextComments[index];
            }
        }
        commentText.text = "";
    }


}
