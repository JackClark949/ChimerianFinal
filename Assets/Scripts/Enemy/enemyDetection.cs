using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySpeed = agent.speed;
        Time.timeScale = 1;
    }

    private void Update()
    {
        enemySightDetection();
    }

    private void enemySightDetection()
    {
        RaycastHit hit;


        if (Physics.Raycast(enemysight.position, enemysight.forward, out hit, enemySightRange))
        {

            if (hit.collider.CompareTag("Player"))
            {
                agent.SetDestination(player.position); // Chase the player
            }
            else
            {

                //HandleWallDetection(hit);
            }
        }
        else
        {

            patrol.Patrol();
        }
    }

   /* private void HandleWallDetection(RaycastHit hit)
    {

        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            gameObject.transform.Rotate(0, -180, 0);
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = enemysight.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(enemysight.position, direction * enemySightRange);
    }
}


