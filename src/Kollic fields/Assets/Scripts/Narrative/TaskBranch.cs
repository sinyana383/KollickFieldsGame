using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTaskBranch", menuName = "Task System/TaskBranch")]
public class TaskBranch : ScriptableObject
{
    public enum TaskState
    {
        NotStarted,
        Started,
        InProcess,
        Completed,
        Failed
    }
    public string title;
    public TaskState taskState;
    
    [Header("")]
    public Comment startComment;
}

