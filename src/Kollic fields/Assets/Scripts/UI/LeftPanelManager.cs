using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanelManager : MonoBehaviour
{
    [SerializeField] AudioSourceSetting audioSettings;
    [SerializeField] Button saveButton;
    [SerializeField] private TextMeshProUGUI warningText;

    public enum PanelNames
    {
        Comments,
        Menu,
        ExitZoneEnsure
    }
    [SerializeField] private Transform[] panels;

    private void Awake()
    {
        audioSettings = GetComponentInChildren<AudioSourceSetting>();
    }

    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            button.onClick.AddListener(ButtonClickSound);
        }
    }

    public void ButtonClickSound()
    {
        audioSettings.AudioPlayOneShot(0);
    }

    private void OnEnable()
    {
        EventManager.Zone.OnWarningEntered += PrepareWarningPanel;
        EventManager.Player.OnMenuSwitch += SwitchMenu;
        EventManager.Save.OnSaveAllDisable += DisableSaveButton;
        EventManager.Save.OnSaveAllEnable += EnableSaveButton;
    }

    private void EnableSaveButton()
    {
        saveButton.interactable = true;
    }

    private void DisableSaveButton()
    {
        saveButton.interactable = false;
    }

    private void OnDisable()
    {
        EventManager.Zone.OnWarningEntered -= PrepareWarningPanel;
        EventManager.Player.OnMenuSwitch -= SwitchMenu;
        EventManager.Save.OnSaveAllDisable -= DisableSaveButton;
        EventManager.Save.OnSaveAllEnable -= EnableSaveButton;
    }

    public void PrepareWarningPanel(string warning)
    {
        warningText.text = warning;
        ShowPanel(PanelNames.ExitZoneEnsure);
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

    public void SwitchMenu()
    {
        if (panels[(int)PanelNames.Menu].gameObject.activeSelf)
        {
            ShowPanel(PanelNames.Comments);
        }
        else
        {
            ShowPanel(PanelNames.Menu);
        }
            
    }
}
