using UnityEngine;

public class Idol : MonoBehaviour
{
    [SerializeField] private string savefileName = "idol";
    public Breakable breakable;

    public void Awake()
    {
        breakable = GetComponentInChildren<Breakable>();
    }
    
    private void Start()
    {
        LoadIdol();
    }

    private void OnEnable()
    {
        EventManager.Save.OnSaveGame += SaveIdol;
    }

    private void OnDisable()
    {
        EventManager.Save.OnSaveGame -= SaveIdol;
    }
    
    public void SaveIdol() => SaveManager.SaveData(new SaveData.IdolData(this), savefileName);

    public void LoadIdol() 
    {
        SaveData.IdolData idolData = SaveManager.LoadData<SaveData.IdolData>(savefileName);
        
        if (idolData == null)
        {
            return;
        }
        
        breakable.toughness = idolData.toughness;
        if (breakable.toughness <= 0)
            breakable.gameObject.SetActive(false);
    }
}
