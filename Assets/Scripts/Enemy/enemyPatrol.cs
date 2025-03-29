using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    private NavMeshAgent agent;
    public GameObject player;
    [SerializeField]
    private float patrolSpeed = 3f;

    [SerializeField]
    private float waypointReachThreshold = 1f;

    private void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;


        if (patrolPoints.Length > 0)
        {

            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void Update()
    {

    }

    public void Patrol()
    {

        if (!agent.pathPending && agent.remainingDistance <= waypointReachThreshold)
        {

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;


            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    public void StopPatrol()
    {
        agent.SetDestination(player.transform.position);
    }
}
