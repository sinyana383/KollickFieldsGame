using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskGraph", menuName = "Scriptable Objects/TaskGraph")]
public class TaskGraph : ScriptableObject
{
    public List<TaskNode> allTasks;
}
