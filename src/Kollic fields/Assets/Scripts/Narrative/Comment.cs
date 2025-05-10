using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comment", menuName = "Scriptable Objects/Comment")]
public class Comment : ScriptableObject
{
    public string textLine;
    public AudioClip voiceLine;
    
    [Header("Next comment depends on subjets state")]
    public GameState.SubjectType subjectsToCheck;
    public List<Comment> nextComments;
    
    [Header("Task to change and it's new state")]
    public List<TaskBranch.TaskState> taskState;
    public List<TaskBranch> tasksToChange;
}
