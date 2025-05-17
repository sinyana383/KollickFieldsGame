using System;
using ChristinaCreatesGames.Typography.Typewriter;
using UnityEngine;

public class TypewriterManager : MonoBehaviour
{
    [SerializeField]
    TypewriterEffect typewriterEffect;

    [SerializeField] private string[] texts;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        if (typewriterEffect == null)
            return;
        
        typewriterEffect.enabled = true;
        typewriterEffect.SetText(texts[0]);
    }
}
