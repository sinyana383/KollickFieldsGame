using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ClosablePanel : MonoBehaviour
{
    [SerializeField] Transform mainPanel;
    [SerializeField] Button closeButton;
    void Start()
    {
        if (closeButton == null)
            closeButton = GetComponentInChildren<Button>();
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);
        if (mainPanel != null)
            this.mainPanel.gameObject.SetActive(true);
    }
}
