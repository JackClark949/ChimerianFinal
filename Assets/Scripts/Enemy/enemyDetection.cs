using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class enemyDetection : MonoBehaviour
{
    //Ref to enemyPatrol 
    public enemyPatrol patrol;
    //NavmeshAgent
    private NavMeshAgent agent;
    //EnemySpeed
    private float enemySpeed = 5f;
    //PLayerRef
    [SerializeField]
    private Transform player;
    //AggroRange and IsChasingPlayer

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
        //Vector3 Distance calculates the distance between the enemy and players position

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //If distance to player is less than enemyAgroRange
        //EnemyPAtrol will 
        if (distanceToPlayer <= enemyAgroRange)
        {
            if (!isChasingPlayer)
            {
                //Stops patrol Coroutine 
                patrol.StopCoroutine(patrol.Patrol());
                //This bool becomes true as enemy is now chasing 
                isChasingPlayer = true;
            }
            //Sets enemy destination to player 
            agent.SetDestination(player.position);
        }
        else
        {
            if (isChasingPlayer)
            {
                //Resume Patrolling 
                patrol.StartCoroutine(patrol.Patrol());
                //StopChasing
                isChasingPlayer = false;
            }
        }
    }


}


















