using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Transform player;

    public AState currentState;
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public AttackState attackState = new AttackState();
    public DeadState deadState = new DeadState();

    public float walkSpeed;
    public float agroDistance;
    public float attackDistance;

    public void DisableAgent() 
    {
        agent.enabled = false;
    }

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
        animator = GetComponent<Animator>();
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
        if (currentState != deadState)
            agent.SetDestination(player.position);
        if (currentState != null)
            currentState.UpdateState(this);
    }
    public void SetSpeed(float newSpeed)
    {
        if (currentState != deadState)
            agent.speed = newSpeed;
    }

    public Vector3 CheckOnTargetRotation()
    {
        return (player.position - transform.position);
    }

    public void RotateTowards(Vector3 direction) 
    {
        var q = Quaternion.LookRotation(CheckOnTargetRotation());
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3f * Time.deltaTime);
        Debug.Log("Rotation!");
    }

    public float CheckOnTarget()
    {
        return (transform.position - player.position).magnitude;
    }
   
    
    }



