using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Transform enemysight;
    [SerializeField]
    private float enemySightRange = 20f;
    private bool IsPlayerDetected;
    [SerializeField]
    private float fieldOfViewRange = 68f;
    [SerializeField]
    private float minPlayerDetectionDistance = 1f;
    private float rayRange = 20f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySpeed = agent.speed;

    }

    private void Update()
    {
        CanSeePlayer();
    }




    protected bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewRange * 0.5f)
        {
            if (Physics.Raycast(enemysight.position, enemysight.forward, out hit, fieldOfViewRange))
            {
                patrol.StopPatrol();

                //Debug.Log("Chasing Player");

                return (hit.transform.CompareTag("Player"));

            }

        }
        patrol.Patrol();
        return false;









    }

    private void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.red;
            Vector3 direction = enemysight.TransformDirection(Vector3.forward);
            Gizmos.DrawWireCube(enemysight.position, direction * minPlayerDetectionDistance);
        }
    }
}




