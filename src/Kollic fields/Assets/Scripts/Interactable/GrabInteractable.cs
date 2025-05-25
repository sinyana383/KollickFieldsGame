using System;
using UnityEngine;

public class GrabInteractable : MonoBehaviour
{
    [SerializeField] private string uniqueName; // Useful for saving/loading

    private void OnEnable()
    {
        EventManager.Save.OnSaveGame += SaveGrabInteractable;
    }

    private void OnDisable()
    {
        EventManager.Save.OnSaveGame -= SaveGrabInteractable;
    }
    
    public void SaveGrabInteractable() => SaveManager.SaveData(new SaveData.GrabInteractableData(this), uniqueName);
    public void LoadGrabInteractable() 
    {
        SaveData.GrabInteractableData grabInteractableData = SaveManager.LoadData<SaveData.GrabInteractableData>(uniqueName);
        
        if (grabInteractableData == null)
        {
            return;
        }
        
        Vector3 position = new Vector3(grabInteractableData.position[0], grabInteractableData.position[1], grabInteractableData.position[2]);
        this.transform.position = position;
    }
    
    private void Awake()
    {
        // Assign unique name if not already set (e.g., from a save file)
        if (string.IsNullOrEmpty(uniqueName))
        {
            uniqueName = $"GrabInteractable_{this.name}";
        }
    }

    private void Start()
    {
        LoadGrabInteractable();
    }
}