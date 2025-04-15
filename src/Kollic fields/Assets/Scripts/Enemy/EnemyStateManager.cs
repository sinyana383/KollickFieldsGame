using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] Transform target;

    AState currentState;
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public AttackState attackState = new AttackState();

    public float walkSpeed;
    public float agroDistance;

    public void SwitchState(AState state) 
    {
        if (currentState != null)
            currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            player = FindAnyObjectByType<XROrigin>().transform;

        //agent.SetDestination(player.position);

        SetDistination(player);
        agent.destination = target.position;
        if (currentState != null)
            currentState.UpdateState(this);
    }
    public void SetSpeed(float newSpeed) 
    {
        agent.speed = newSpeed;
    }
    public void SetDistination(Transform newDestination) 
    {
        target = newDestination;
    }

    public float CheckOnTarget() 
    {
        return (transform.position - target.position).magnitude;
    }
}
