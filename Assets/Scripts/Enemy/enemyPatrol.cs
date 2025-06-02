using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour
{
    //Script Taken from:https://github.com/yasmeen2001234/individual_scripts/blob/main/Agent_AI.cs
    //Declare an Array to store patrolPoints that enemy will move from 
    [SerializeField]
    private Transform[] patrolPoints;
    //Keeps track of currentWayPoint
    private int currentWaypointIndex = 0;

    private NavMeshAgent agent;

    [SerializeField]
    private float patrolSpeed = 3f;
    //Waypoint threshold to see if enemy has reached the next waypoint
    [SerializeField]
    private float waypointReachThreshold = 1f;

    


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        //Start Patrol Coroutine
        StartCoroutine(Patrol());



    }

    public IEnumerator Patrol()
    {
        //Enemies will patrol infintely 
        while (true)
        {
            //Agent not calculating path and reached current destination 
            if (!agent.pathPending && agent.remainingDistance <= waypointReachThreshold)
            {
                //Move to next waypoint or loop back to first point if at the last one
                currentWaypointIndex = (currentWaypointIndex + 1) % patrolPoints.Length;
                //Set next destination for enemy to go to 
                agent.SetDestination(patrolPoints[currentWaypointIndex].position);
            }
            //Waits for next frame
            yield return null;
        }
    }



}
