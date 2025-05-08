using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comment", menuName = "Scriptable Objects/Comment")]
public class Comment : ScriptableObject
{
    public string textLine;
    public AudioClip voiceLine;
    
    public List<Comment> nextComments;
}
