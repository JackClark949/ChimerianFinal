using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class miniBer : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    

   


    void Start()
    {
     agent = GetComponent<NavMeshAgent>();
     
    }

    private void Awake()
    {
        player = FindObjectOfType<playerMovement>().transform;
    }

    private void DetectPlayer()
    {
        agent.SetDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }
}
