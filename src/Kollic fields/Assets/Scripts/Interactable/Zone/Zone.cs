using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] protected bool enteredZone = false;

    private void Start()
    {
        if (audioSource == null) 
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        FunctionOnTriggerEnter(other);
    }

    protected virtual void FunctionOnTriggerEnter(Collider other)
    {
        if (!enteredZone) 
        {
            if (audioSource != null)
                audioSource.Play();
            enteredZone = true;
        }
    }
}
