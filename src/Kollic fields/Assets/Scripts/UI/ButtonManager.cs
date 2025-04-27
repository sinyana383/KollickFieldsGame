using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Transform mainPanel;
    public Transform controlsPanel;
    public Transform settingsPanel;

    
    public Button playButton;
    public Button controlsButton;
    public Button settingsButton;
    public Button exitButton;
    
    void Start () {
        playButton.onClick.AddListener(TaskOnClick);
        controlsButton.onClick.AddListener(OpenControls);
    }

    void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
    }

    void OpenControls()
    {
        mainPanel.gameObject.SetActive (false);
        controlsPanel.gameObject.SetActive (true);
    }
}
