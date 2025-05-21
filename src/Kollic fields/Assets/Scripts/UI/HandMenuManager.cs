using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI.BodyUI;

public class HandMenuManager : MonoBehaviour
{
    [SerializeField] private Button savePanelButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Transform savePanel;

    private void Start()
    {
        saveButton.onClick.AddListener(() =>EventManager.Save.OnSaveAll?.Invoke());
        saveButton.onClick.AddListener(() => savePanel.gameObject.SetActive(false));
        savePanelButton.onClick.AddListener(() => savePanel.gameObject.SetActive(true));
    }
}
