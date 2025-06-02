using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class miniBer : MonoBehaviour
{
    //Navmesh ref and Player as enemy needs a reference to chase player
    NavMeshAgent agent;
    public Transform player;
    
   

   


    void Start()
    {
     agent = GetComponent<NavMeshAgent>();
     
    }
    //Instantly find gameobject with playermovement
    //Get its transform

    private void Awake()
    {
        player =   FindObjectOfType<playerMovement>().transform;
    }

    //Mini enemy will constantly chase the player
    //When it's spawned in it's destination will be set to the player
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
