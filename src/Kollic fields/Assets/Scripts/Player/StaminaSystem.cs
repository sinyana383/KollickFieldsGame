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
        currentStamina = maxStamina;
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
        while (currentStamina > 0)
        {
            currentStamina -= staminaUseRate * Time.deltaTime;
            currentStamina = Mathf.Max(0, currentStamina);
            Debug.Log("Stamina: " + currentStamina);

            if (currentStamina <= 0)
            {
                StopUsingStamina();
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator RegenerateStamina()
    {
        while (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(maxStamina, currentStamina);
            Debug.Log("Stamina: " + currentStamina);
            yield return null;
        }
    }
}
