using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManger : MonoBehaviour
{
    public List<TaskBranch> tasksPool;
    public List<TaskBranch> activeTasks;
    
    [Header("UI")]
    public TextMeshProUGUI commentText;

    public float delayBetweenComments = 3f;

    private void Start()
    {
        activeTasks.Add(tasksPool[0]);
        activeTasks[0].taskState = TaskBranch.TaskState.Started;
    }

    private void OnEnable()
    {
        EventManager.Bodies.OnBodiesFound += () => StartComments(activeTasks[0]);
    }

    private void OnDisable()
    {
        EventManager.Bodies.OnBodiesFound -= () => StartComments(activeTasks[0]);

    }
    
    public void StartComments(TaskBranch task)
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

            yield return new WaitForSeconds(delayBetweenComments);
            
            curComment = curComment.nextComments[(int)curComment.subjectsToCheck];
        }
    }


}
