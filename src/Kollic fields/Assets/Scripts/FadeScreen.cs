using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 1f;
    public Color fadeColor;
    Renderer rend;

    private void OnEnable()
    {
        EventManager.Zone.OnWarningEntered += WarningScreenFadeEnter;
        EventManager.Zone.OnPlayerRelease += WarningScreenFadeExit;
    }
    
    private void OnDisable()
    {
        EventManager.Zone.OnWarningEntered -= WarningScreenFadeEnter;
        EventManager.Zone.OnPlayerRelease -= WarningScreenFadeExit;
    }

    public void WarningScreenFadeEnter(string warningText)
    {
        // Debug.Log("WarningScreenFadeEnter");
        Fade(0, 0.8f);
    }
    public void WarningScreenFadeExit()
    {
        // Debug.Log("WarningScreenFadeExit");
        Fade(0.8f, 0);
    }
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }
    public void FadeOut()
    {
        Fade(0, 1);
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_BaseColor", newColor);
            
            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
        rend.material.SetColor("_BaseColor", newColor2);
    }
}
