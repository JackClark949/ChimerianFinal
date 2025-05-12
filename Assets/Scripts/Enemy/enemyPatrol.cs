using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentWaypointIndex = 0;

    private NavMeshAgent agent;

    [SerializeField]
    private float patrolSpeed = 3f;

    [SerializeField]
    private float waypointReachThreshold = 1f;

    public Transform player;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        StartCoroutine(Patrol());



    }

    public IEnumerator Patrol()
    {
        while (true)
        {

            if (!agent.pathPending && agent.remainingDistance <= waypointReachThreshold)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentWaypointIndex].position);
            }
            yield return null;
        }
    }



}
