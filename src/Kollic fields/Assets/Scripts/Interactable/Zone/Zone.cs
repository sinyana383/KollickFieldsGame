using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] AudioSourceSetting audioSourceSetting;
    [SerializeField] protected bool enteredZone = false;

    private void Awake()
    {
        if (audioSourceSetting == null) 
        {
            audioSourceSetting = GetComponent<AudioSourceSetting>();
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
            if (audioSourceSetting != null)
                audioSourceSetting.AudioPlayOneShot(0);
            enteredZone = true;
        }
    }
}
