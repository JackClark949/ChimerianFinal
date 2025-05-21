using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class miniBer : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public Transform berSight;
    private float rayCast = 20f;

   


    void Start()
    {
     agent = GetComponent<NavMeshAgent>();
     
    }

    private void Awake()
    {
        player =    FindObjectOfType<playerMovement>().transform;
    }

    private void DetectPlayer()
    {
        RaycastHit hit;
        if(Physics.Raycast(berSight.position, berSight.forward, out hit, rayCast))
        {
            
            if(player != null)
            {
                hit.transform.CompareTag("Player");
                agent.SetDestination(player.transform.position);
            }
               
            
            



        }
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }
}
