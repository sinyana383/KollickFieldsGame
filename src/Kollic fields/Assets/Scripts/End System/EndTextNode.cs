using UnityEngine;

[CreateAssetMenu(fileName = "EndTextNode", menuName = "Scriptable Objects/EndTextNode")]
public class EndTextNode : ScriptableObject
{
    public string text;
    public GameState.SubjectType subjectsToCheck;
    public EndTextNode[] nextNodes;
}
