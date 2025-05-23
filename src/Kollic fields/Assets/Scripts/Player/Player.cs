using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private string savefileName = "player";
    [SerializeField] int hp = 100;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    
    private void Start()
    {
        LoadPlayerParameters();
    }

    private void OnEnable()
    {
        EventManager.Save.OnSaveGame += SavePlayerParameters;
    }

    private void OnDisable()
    {
        EventManager.Save.OnSaveGame -= SavePlayerParameters;
    }

    public void SavePlayerParameters() => SaveManager.SaveData(new SaveData.PlayerData(this), savefileName);
    public void LoadPlayerParameters() 
    {
        SaveData.PlayerData playerData = SaveManager.LoadData<SaveData.PlayerData>(savefileName);
        
        if (playerData == null)
        {
            return;
        }
        
        Vector3 position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        this.transform.position = position;
        HP = playerData.hp;
    }
    void PlayerDead()
    {
        EventManager.GameOver.OnGameOver?.Invoke();
        SceneManager.LoadScene(0);
        Debug.Log("Player is dead");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Trigger enter: {other.name}");
        if (other.gameObject.TryGetComponent(out EnemyDamager enemyDamager))
        {
            this.hp -= enemyDamager.enemyDmg;
            Debug.Log($"Player hp: {hp}");
            if (this.hp <= 0)
            {
                PlayerDead();
            }
        }
    }
}
