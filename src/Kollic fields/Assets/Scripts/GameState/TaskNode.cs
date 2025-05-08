using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTaskNode", menuName = "Task System/Task Node")]
public class TaskNode : ScriptableObject
{
    public string title;
    public List<Comment> comments;
    
    
    public List<TaskNode> nextTasks;
}

