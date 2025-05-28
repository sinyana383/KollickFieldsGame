using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private string savefileName = "player";
    [SerializeField] int maxHp = 100;
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
            EventManager.Player.OnHealthChanged?.Invoke((float)hp/maxHp);
        }
    }
    
    private void Start()
    {
        if (!LoadPlayerParameters())
            HP = maxHp;
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
    public bool LoadPlayerParameters() 
    {
        SaveData.PlayerData playerData = SaveManager.LoadData<SaveData.PlayerData>(savefileName);
        
        if (playerData == null)
        {
            return false;
        }
        
        Vector3 position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        this.transform.position = position;
        HP = playerData.hp;
        return true;
    }
    void PlayerDead()
    {
        Debug.Log("Player is dead");
        EventManager.Game.OnGameOver?.Invoke();
        EventManager.Game.OnSceneTransition?.Invoke(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Trigger enter: {other.name}");
        if (other.gameObject.TryGetComponent(out EnemyDamager enemyDamager))
        {
            HP -= enemyDamager.enemyDmg;
            Debug.Log($"Player hp: {HP}");
            if (HP <= 0)
            {
                PlayerDead();
            }
        }
    }
}
