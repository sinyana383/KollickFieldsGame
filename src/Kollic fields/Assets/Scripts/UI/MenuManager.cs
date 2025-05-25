using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    
    [Header("Panels")]
    public Transform mainPanel;
    public Transform controlsPanel;
    public Transform settingsPanel;
    public Transform newGamePanel;

    [Header("Buttons")]
    public Button continuePlayButton;
    public Button newGameButton;
    public Button clearButton;
    public Button controlsButton;
    public Button settingsButton;
    public Button exitButton;
    
    void Start ()
    {
        if (SaveManager.GetSavedFileNames().Count == 0)
        {
            newGameButton.onClick.AddListener(() => EventManager.Game.OnSceneTransition?.Invoke(1));
            continuePlayButton.interactable = false;
        }
        else
        {
            newGameButton.onClick.AddListener(() => OpenPanel(newGamePanel));
            clearButton.onClick.AddListener(SaveManager.DeleteAllSaves);
            clearButton.onClick.AddListener(() => EventManager.Game.OnSceneTransition?.Invoke(1));
            continuePlayButton.interactable = true;
        }
        continuePlayButton.onClick.AddListener(() => EventManager.Game.OnSceneTransition?.Invoke(1));
        controlsButton.onClick.AddListener(() => OpenPanel(controlsPanel));
        settingsButton.onClick.AddListener(() => OpenPanel(settingsPanel));
        exitButton.onClick.AddListener(QuitGame);

        
        continuePlayButton.onClick.AddListener(ButtonPressEffect);
        controlsButton.onClick.AddListener(ButtonPressEffect);
        settingsButton.onClick.AddListener(ButtonPressEffect);
        exitButton.onClick.AddListener(ButtonPressEffect);
        newGameButton.onClick.AddListener(ButtonPressEffect);
        clearButton.onClick.AddListener(ButtonPressEffect);
    }

    public void ButtonPressEffect() 
    {
        audioManager.PlayButtonPress(audioManager.buttonPress);
    }

    void OpenPanel(Transform panel)
    {
        mainPanel.gameObject.SetActive (false);
        panel.gameObject.SetActive (true);
    }

    void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
