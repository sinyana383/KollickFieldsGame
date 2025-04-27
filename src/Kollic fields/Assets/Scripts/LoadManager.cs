using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    [Header("Don't destroy data")]
    [SerializeField] Volume volume;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
