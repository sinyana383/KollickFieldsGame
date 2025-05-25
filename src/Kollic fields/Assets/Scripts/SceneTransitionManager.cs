using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    LoadManager loadManager;
    public FadeScreen fadeScreen;

    private void Awake()
    {
        fadeScreen = GetComponent<FadeScreen>();
    }

    private void OnEnable()
    {
        EventManager.Game.OnSceneTransition += GoToScene;
    }

    private void OnDisable()
    {
        EventManager.Game.OnSceneTransition -= GoToScene;
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
