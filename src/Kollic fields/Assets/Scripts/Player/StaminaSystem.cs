using System;
using System.Collections;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;

    [Header("Stamina Settings")]
    public float maxStamina = 100f;
    public float staminaUseRate = 20f;      // Per second
    public float staminaRegenRate = 10f;    // Per second
    private float currentStamina;

    public float CurrentStamina
    {
        get{return currentStamina;}
        set
        {
            currentStamina = value;
            EventManager.Player.OnStaminaChanged?.Invoke(currentStamina/maxStamina);
        }
    }

    private Coroutine staminaCoroutine;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void OnEnable()
    {
        EventManager.Player.OnStaminaUseEntered += StartUsingStamina;
        EventManager.Player.OnStaminaUseExited += StopUsingStamina;
    }

    private void OnDisable()
    {
        EventManager.Player.OnStaminaUseEntered -= StartUsingStamina;
        EventManager.Player.OnStaminaUseExited -= StopUsingStamina;
    }

    private void Start()
    {
        CurrentStamina = maxStamina;
    }

    private void StartUsingStamina()
    {
        if (staminaCoroutine != null) StopCoroutine(staminaCoroutine);
        staminaCoroutine = StartCoroutine(DrainStamina());
        playerMove.Accelerate();
    }

    private void StopUsingStamina()
    {
        if (staminaCoroutine != null) StopCoroutine(staminaCoroutine);
        staminaCoroutine = StartCoroutine(RegenerateStamina());
        playerMove.NormalSpeed();
    }

    private IEnumerator DrainStamina()
    {
        while (CurrentStamina > 0)
        {
            CurrentStamina -= staminaUseRate * Time.deltaTime;
            CurrentStamina = Mathf.Max(0, CurrentStamina);
            Debug.Log("Stamina: " + CurrentStamina);

            if (CurrentStamina <= 0)
            {
                StopUsingStamina();
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator RegenerateStamina()
    {
        while (CurrentStamina < maxStamina)
        {
            CurrentStamina += staminaRegenRate * Time.deltaTime;
            CurrentStamina = Mathf.Min(maxStamina, CurrentStamina);
            Debug.Log("Stamina: " + CurrentStamina);
            yield return null;
        }
    }
}
