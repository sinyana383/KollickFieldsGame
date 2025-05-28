using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    enum BarType
    {
        Health,
        Stamina
    }
    [SerializeField] BarType barType;
    [SerializeField] Slider sliderBar;
    [SerializeField] Image fillImage;

    [SerializeField] Color fullBarColor;
    [SerializeField] Color emptyBarColor;
    
    private void Awake()
    {
        if (sliderBar == null)
            sliderBar = GetComponent<Slider>();
        if (fillImage == null)
            fillImage = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        if (barType == BarType.Health)
            EventManager.Player.OnHealthChanged += ChangeValue;
        if (barType == BarType.Stamina)
            EventManager.Player.OnStaminaChanged += ChangeValue;
    }
    
    private void OnDisable()
    {
        if (barType == BarType.Health)
            EventManager.Player.OnHealthChanged -= ChangeValue;
        if (barType == BarType.Stamina)
            EventManager.Player.OnStaminaChanged -= ChangeValue;
    }

    private void ChangeValue(float value)
    {
        float t = Mathf.Clamp01(value);
        sliderBar.value = t;
        fillImage.color = fillImage.color = Color.Lerp(emptyBarColor, fullBarColor, t);
    } 
}
