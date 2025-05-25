using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Akratit : MonoBehaviour
{
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private string savefileName = "akratit";
    public int hp = 100;
    public bool isDead;
    [SerializeField] EnemyStateManager enemyStateManager;

    private void OnEnable()
    {
        EventManager.Akratit.OnAkratitHit += GetDamage;
        EventManager.Save.OnSaveGame += SaveAkratitParameters;
    }
    private void OnDisable()
    {
        EventManager.Akratit.OnAkratitHit -= GetDamage;
        EventManager.Save.OnSaveGame -= SaveAkratitParameters;
    }

    private void Start()
    {
        LoadAkratitParameters();
    }

    public void SaveAkratitParameters() => SaveManager.SaveData(new SaveData.AkratitData(this), savefileName);
    public void LoadAkratitParameters() 
    {
        SaveData.AkratitData akratitData = SaveManager.LoadData<SaveData.AkratitData>(savefileName);
        
        if (akratitData == null)
        {
            return;
        }
        
        Vector3 position = new Vector3(akratitData.position[0], akratitData.position[1], akratitData.position[2]);
        this.transform.position = position;
        Vector3 rotation = new Vector3(akratitData.rotation[0], akratitData.rotation[1], akratitData.rotation[2]);
        this.transform.rotation = Quaternion.Euler(rotation);
        this.hp = akratitData.hp;
        this.isDead = akratitData.isDead;

        if (isDead)
        {
            GameObject dead = Instantiate(deadPrefab, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        isDead = false;
        enemyStateManager = GetComponent<EnemyStateManager>();
    }

    private void GetDamage(int damage) 
    {
        this.hp -= damage;
        Debug.Log($"HP: {hp}");
        if (this.hp <= 0 && !isDead) 
            Dead();
    }

    void Dead()
    {
        isDead = true;
        enemyStateManager.SwitchState(enemyStateManager.deadState);
        //Destroy(this.gameObject);
    }
}
