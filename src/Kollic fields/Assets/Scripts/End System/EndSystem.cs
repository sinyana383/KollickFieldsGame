using System;
using End_System;
using UnityEngine;

public class EndSystem : MonoBehaviour
{
    [SerializeField]
    TypewriterEffect typewriterEffect;

    [SerializeField] private string[] texts;

    private void Awake()
    {
        typewriterEffect = GetComponentInChildren<TypewriterEffect>();
    }

    private void Start()
    {
        if (typewriterEffect == null)
            return;
        
        typewriterEffect.enabled = true;
        typewriterEffect.SetText(texts[0]);
    }
}
