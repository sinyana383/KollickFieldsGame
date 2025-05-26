using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    enum Sounds
    {
        ButtonClick,
    }
    [SerializeField] private AudioSourceSetting audioSetting;
    
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

    private void Awake()
    {
        audioSetting = GetComponentInChildren<AudioSourceSetting>();
    }

    void Start ()
    {
        Button[] buttons = this.GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            button.onClick.AddListener(ButtonPressEffect);
        }
        
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
    }

    public void ButtonPressEffect() 
    {
        audioSetting.AudioPlayOneShot((int)Sounds.ButtonClick);
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
