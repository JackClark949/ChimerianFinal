using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private float patrolSpeed = 3f;

    [SerializeField]
    private float waypointReachThreshold = 1f;

    private void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = patrolSpeed;


        if (patrolPoints.Length > 0)
        {

            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void Update()
    {
        Patrol();
    }

    public void Patrol()
    {

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= waypointReachThreshold)
        {

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;


            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
}
