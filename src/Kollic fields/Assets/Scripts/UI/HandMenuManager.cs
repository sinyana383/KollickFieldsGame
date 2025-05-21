using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI.BodyUI;

public class HandMenuManager : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button savePanelButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;
    
    [SerializeField] private Transform savePanel;
    [SerializeField] private Transform controlsPanel;
    [SerializeField] private Transform settingsPanel;
    

    private void Start()
    {
        saveButton.onClick.AddListener(() =>EventManager.Save.OnSaveAll?.Invoke());
        saveButton.onClick.AddListener(() => savePanel.gameObject.SetActive(false));
        savePanelButton.onClick.AddListener(() => savePanel.gameObject.SetActive(true));
        controlsButton.onClick.AddListener(() => controlsPanel.gameObject.SetActive(true));
        settingsButton.onClick.AddListener(() => settingsPanel.gameObject.SetActive(true));
    }
}
