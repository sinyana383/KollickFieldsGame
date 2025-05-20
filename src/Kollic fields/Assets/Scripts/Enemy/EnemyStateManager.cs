using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyStateManager : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    
    [SerializeField] public Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Transform player;

    public AState currentState;
    public PatrolState PatrolState = new PatrolState();
    public AgroState AgroState = new AgroState();
    public AttackState attackState = new AttackState();
    public DeadState deadState = new DeadState();

    public float walkSpeed;
    public float agroDistance;
    public float attackDistance;

    public void DisableAgent() 
    {
        agent.enabled = false;
    }

    public void SetAutoBreaking(bool autoBreaking)
    {
        agent.autoBraking = autoBreaking;
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
    void Start()
    {
        SwitchState(PatrolState);
    }
    
    void Update()
    {
        if (!player)
            player = FindAnyObjectByType<XROrigin>().transform;
        if (currentState != deadState && currentState != PatrolState)
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
        // Debug.Log("Rotation!");
    }

    public float CheckOnTarget()
    {
        return (transform.position - player.position).magnitude;
        
    }
   
    public float GetRemainingDistance()
    {
       return agent.remainingDistance;
    }
    
    public void GotoNextPoint() {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    
    }



