using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI.BodyUI;

public class HandMenuManager : MonoBehaviour
{
    [Header("Function buttons")]
    [SerializeField] private Button saveButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button exitButton;
    
    [Header("Panel Buttons")]
    [SerializeField] private Button savePanelButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button mainMenuPanelButton;
    [SerializeField] private Button exitPanelButton;
    
    [Header("Panels")]
    [SerializeField] private Transform savePanel;
    [SerializeField] private Transform controlsPanel;
    [SerializeField] private Transform settingsPanel;
    [SerializeField] private Transform mainMenuPanel;
    [SerializeField] private Transform exitPanel;
    

    private void Start()
    {
        saveButton.onClick.AddListener(() =>EventManager.Save.OnSaveGame?.Invoke());
        saveButton.onClick.AddListener(() => savePanel.gameObject.SetActive(false));
        
        savePanelButton.onClick.AddListener(() => savePanel.gameObject.SetActive(true));
        controlsButton.onClick.AddListener(() => controlsPanel.gameObject.SetActive(true));
        settingsButton.onClick.AddListener(() => settingsPanel.gameObject.SetActive(true));
        
        mainMenuPanelButton.onClick.AddListener(() => mainMenuPanel.gameObject.SetActive(true));
        mainMenuButton.onClick.AddListener(() => EventManager.Game.OnSceneTransition?.Invoke(0));
        
        exitPanelButton.onClick.AddListener(() => exitPanel.gameObject.SetActive(true));
        exitButton.onClick.AddListener(() => Application.Quit());
    }
}
