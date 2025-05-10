using System;
using TMPro;
using UnityEngine;

public class TaskBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;

    private void Start()
    {
        titleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeTitle(string title)
    {
        if (titleText == null)
            titleText = GetComponentInChildren<TextMeshProUGUI>();
        
        titleText.text = title;
    }
}
