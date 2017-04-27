using UnityEngine;
using System.Collections;

public class AINavigation : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public bool enemySighted;
    public bool turretSighted;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    public bool noTarget;
    public Vector3 destination;


    void Start()
    {
        InvokeRepeating("NewPosition", 0f, 0.5f);
    }

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        enemySighted = false;
        turretSighted = false;
        noTarget = true;
    }

    void Update()
    {
        if (target.position == destination)
        {
            noTarget = true; // if you dont have a target...
            NewPosition();   // get a new target.
        }
        else if (noTarget == true)
        {
            NewPosition();
        }
    }

    void NewPosition()
    {
        if (enemySighted == false && turretSighted == false) // if you dont see any targets
        {
           if (noTarget == true) // if you dont have a current destination
           {
                noTarget = false;
                destination = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(destination);
           }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySighted = true;
            Vector3 newPos = transform.position;
            agent.SetDestination(newPos);
        }

        else if (other.tag == "Ally")
        {
            turretSighted = true;
            Vector3 newPos = transform.position;
            agent.SetDestination(newPos);
        }
        else
        {
            enemySighted = false;
            turretSighted = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySighted = false;
            Debug.Log("enemy lost");
            Vector3 newPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            agent.SetDestination(newPos);
        }

        if(other.tag == "Ally")
        {
            turretSighted = false;
        }
    }

    public void TookDamage()
    {

    }
}
