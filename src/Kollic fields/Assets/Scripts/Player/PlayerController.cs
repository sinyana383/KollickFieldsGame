using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected InputController input;

    protected void Awake()
    {

        input = new InputController();
    }

    protected virtual void OnEnable()
    {
        input.Enable();
    }


    protected virtual void OnDisable()
    {
        input.Disable();
    }

}
