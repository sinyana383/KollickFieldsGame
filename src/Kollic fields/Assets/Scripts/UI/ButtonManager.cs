using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private LoadManager loadManager;
    [SerializeField] private AudioManager audioManager;
    
    [Header("Panels")]
    public Transform mainPanel;
    public Transform controlsPanel;
    public Transform settingsPanel;

    [Header("Buttons")]
    public Button playButton;
    public Button controlsButton;
    public Button settingsButton;
    public Button exitButton;
    
    void Start ()
    {
        playButton.onClick.AddListener(loadManager.LoadLevel);
        controlsButton.onClick.AddListener(() => OpenPanel(controlsPanel));
        settingsButton.onClick.AddListener(() => OpenPanel(settingsPanel));
        exitButton.onClick.AddListener(QuitGame);

        
        playButton.onClick.AddListener(ButtonPressEffect);
        controlsButton.onClick.AddListener(ButtonPressEffect);
        settingsButton.onClick.AddListener(ButtonPressEffect);
        exitButton.onClick.AddListener(ButtonPressEffect);
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
