using System;
using End_System;
using UnityEngine;
using UnityEngine.UI;

public class EndSystem : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] TypewriterEffect typewriterEffect;
    [SerializeField] Button nextButton;
    [SerializeField] Button skipButton;
    
    
    [SerializeField] private EndTextNode curNode;
    [SerializeField] private EndTextNode endNode;
    [SerializeField] private EndTextNode startNode;
    private void OnEnable()
    {
        EventManager.EndText.OnTextRevealed += ShowButton;
    }

    private void OnDisable()
    {
        EventManager.EndText.OnTextRevealed -= ShowButton;
    }

    private void Awake()
    {
        typewriterEffect = GetComponentInChildren<TypewriterEffect>();
        scrollRect = GetComponentInChildren<ScrollRect>();
        // nextButton = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        if (GameState.Instance.gameOver)
            curNode = endNode;
        else
        {
            curNode = startNode;
        }
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(()=>PrintText(curNode));
            nextButton.onClick.AddListener(()=>nextButton.interactable = false);
            nextButton.onClick.AddListener(()=>scrollRect.verticalNormalizedPosition = 1f);
            nextButton.interactable = false;
        }

        if (skipButton != null)
        {
            skipButton.onClick.AddListener(() => typewriterEffect.Skip(true));
        }
        PrintText(curNode);
    }

    private void PrintText(EndTextNode node)
    {
        if (typewriterEffect == null)
            return;
        
        typewriterEffect.enabled = true;
        Debug.Log(node.text);
        typewriterEffect.SetText(node.text);
    }

    public void ShowButton()
    {
        if (curNode == null || curNode.nextNodes == null || curNode.nextNodes.Length == 0)
            return;
        while (curNode != null && curNode.nextNodes != null && curNode.nextNodes.Length != 0)
        {
            int index = (int)GameState.Instance.GetSubjectState(curNode.subjectsToCheck);
            Debug.Log($"{curNode} {index}");
            curNode = curNode.nextNodes[index];
            if (!string.IsNullOrEmpty(curNode.text))
                break;
        }
        Debug.Log($"{curNode}");
        if (curNode == null)
            return;
        nextButton.interactable = true;
    }
}
