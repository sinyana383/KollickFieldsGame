using System;
using UnityEngine;
using UnityEngine.UI;

public class ContentSizeFitterFix : MonoBehaviour
{
    [SerializeField] private ContentSizeFitter contentSizeFitter;

    private void Awake()
    {
        ContentSizeFitter contentSizeFitter = GetComponent<ContentSizeFitter>();
    }

    private void Start()
    {
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }
}
