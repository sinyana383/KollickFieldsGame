using System;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI warningText;

    public enum PanelNames
    {
        Comments,
        Menu,
        ExitZoneEnsure
    }
    [SerializeField] private Transform[] panels;
    
    private void OnEnable()
    {
        EventManager.Zone.OnWarningEntered += PrepareWarningPanel;
    }

    private void OnDisable()
    {
        EventManager.Zone.OnWarningEntered -= PrepareWarningPanel;
    }

    public void PrepareWarningPanel(string warning)
    {
        warningText.text = warning;
        ShowPanel(PanelNames.ExitZoneEnsure);
    }
    
    public void ShowPanel(PanelNames name)
    {
        Debug.Log($"PanelManager.ShowPanel(PanelNames.{name})");
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
}
