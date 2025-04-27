using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button playButton;
    
    void Start () {
        playButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
    }
}
