using System;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public enum PanelNames
    {
        Comments,
        Menu,
        ExitZoneEnsure
    }
    [SerializeField] private Transform[] panels;
    private void OnEnable()
    {
        EventManager.Zone.OnFieldExit += (() => ShowPanel(PanelNames.ExitZoneEnsure));
    }

    private void OnDisable()
    {
        EventManager.Zone.OnFieldExit -= (() => ShowPanel(PanelNames.ExitZoneEnsure));
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
