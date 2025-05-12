using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class enemyDetection : MonoBehaviour
{
    public enemyPatrol patrol;
    private NavMeshAgent agent;
    private float enemySpeed = 5f;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float enemyAgroRange = 2f;
    private bool isChasingPlayer = true;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySpeed = agent.speed;




    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= enemyAgroRange)
        {
            if (!isChasingPlayer)
            {

                patrol.StopCoroutine(patrol.Patrol());
                isChasingPlayer = true;
            }
            agent.SetDestination(player.position);
        }
        else
        {
            if (isChasingPlayer)
            {

                patrol.StartCoroutine(patrol.Patrol());
                isChasingPlayer = false;
            }
        }
    }


}


















