using System;
using Unity.VisualScripting;
using UnityEngine;

public class RightPanelManager : MonoBehaviour
{
    public enum PanelNames
    {
        Tasklist
    }
    [SerializeField] private Transform[] panels;

    private void OnEnable()
    {
        EventManager.Player.OnTaskListSwitch += SwitchTaskList;
    }
    
    private void OnDisable()
    {
        EventManager.Player.OnTaskListSwitch -= SwitchTaskList;
    }

    private void Start()
    {
        ShowPanel(PanelNames.Tasklist);
    }
    public void ShowPanel(PanelNames name)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == (int)name)
                panels[i].gameObject.SetActive(true);
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }

    public void SwitchTaskList()
    {
        Debug.Log("Switch task list");
        if (panels[(int)PanelNames.Tasklist].gameObject.activeSelf)
        {
            panels[(int)PanelNames.Tasklist].gameObject.SetActive(false);
        }
        else
        {
            ShowPanel(PanelNames.Tasklist);
        }
            
    }
}
